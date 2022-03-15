# Express Authenticators [![Build Status](https://travis-ci.org/tranvansang/express-authenticators.svg?branch=master)](https://travis-ci.org/tranvansang/express-authenticators)

[![NPM](https://nodei.co/npm/express-authenticators.png)](https://nodei.co/npm/express-authenticators/)

Modern OAuth/OAuth2 authenticator.

## Features

- Pre-configured for popular providers: Google, Facebook, Foursquare, Github, Twitter, LinkedIn, LINE, Pinterest,
  Tumblr, Instagram.
- Pre-configured for popular scopes: email, profile, etc. with account fetching for basic user information.
- The original OAuth/OAuth2 classes are available for customized providers.
- The only dependencies are `r3986` and `node-fetch`.
- Modern NodeJS. Although, it requires NodeJS >= v14.17.0 to use the `randomUUID()` function.
- Strongly typed with TypeScript.
- Support PKCE([Proof Key for Code Exchange](https://oauth.net/2/pkce/)).
- Generic and pure interface. Do not depend on any framework.

# Usage

- With `yarn`: `yarn add express-authenticators`.
- With `npm`: `npm install --save express-authenticators`.

Note: before `v0.1.0`, this package was for ExpressJS only, hence its name is `express-authenticators`.

## Sample code in ExpressJS

```javascript

const {
	FacebookAuthenticator,
	FoursquareAuthenticator,
	GithubAuthenticator,
	GoogleAuthenticator,
	LineAuthenticator,
	InstagramAuthenticator,
	LinkedInAuthenticator,
	PinterestAuthenticator,
	TumblrAuthenticator,
	TwitterAuthenticator,
	ZaloAuthenticator,
	OAuth2,
	OAuth
} = require('express-authenticators')
const express = require('express')
const session = require('express-session')

const app = express()
app.use(session())

const facebookAuth = new FacebookAuthenticator({
	clientID: 'facebook app id',
	clientSecret: 'facebook app secret',
	redirectUri: `https://example.com/auth/facebook/callback`,
})

app.get(
	'/auth/facebook',
	async (req, res, next) => {
		req.session.someInfo = 'my info' // store the user credential
		try {
			const redirectUrl = await facebookAuth.authenticate({
				store(token) {
					req.session.oauthFacebook = token
				}
			})
			res.status = 302
			res.redirect(redirectUrl)
		} catch (e) {
			next(e)
		}
	}
)
app.get(
	`/auth/facebook/callback`,
	async (req, res, next) => {
		try {
			const payload = await facebookAuth.callback(
				req.session.oauthFacebook,
				new URL(`https://example.com${req.url}`).search
			)
			const profile = await facebookAuth.fetchProfile(payload)
			console.log('got profile', profile)
			res.send(JSON.stringify(profile))
		} catch (e) {
			next(e)
		}
	}
)
```

# API references

Note that NodeJS >= v14.17.0 is required.

## Exported classes

- 2 generic classes: `OAuth2` and `OAuth`.

- Pre-configured providers that inherit `OAuth`: `TwitterAuthenticator`, `TumblrAuthenticator`.
- Pre-configured providers that inherit `OAuth2`:
    - `FacebookAuthenticator`
    - `FoursquareAuthenticator`
    - `GithubAuthenticator`
    - `GoogleAuthenticator`
    - `InstagramAuthenticator`
    - `LinkedInAuthenticator`
    - `PinterestAuthenticator`
    - `LineAuthenticator`
    - `ZaloAuthenticator`

## Constructors

- All pre-configured providers' constructors take only one parameter: `options` with the following properties.

```typescript
{
	clientID: string
	clientSecret: string
	redirectUri: string
}
```

## Most generic methods

All exported classes inherit the `IOAuthCommon` interface which has the following methods:

- `authenticate(session: {store(token: string): void | Promise<void>}): string | Promise<string>`.
    - Input: this method takes only one argument, `session` whose `store` method is called with a token in `string` type
      to store in the request session. This data will be required in the succeeding `callback()` method.
    - Output: redirect url. The controller/router should redirect the user to this url. This function always returns
      a `string` type or throws an error if it fails.

- `callback({pop}: {pop(): string | undefined}, rawQuery: string)`:
    - Input: `pop` is a function that returns the token from the request session. This token is required to validate the
      authentication.
    - Input: `rawQuery` is the query string from the callback url, the query may or may not contain the leading `?` character (internally, we use `URLSearchParams` which handles this automatically).
    - Output: the token payload returned from the provider. For `OAuth` providers, this
      is `{token: string, secret: string}`. For `OAuth2` providers, the payload is the JSON-parsed response from the
      provider which usually contains the token for further request.

## Pre-configured providers' methods

Pre-configured providers have the following methods:

- `fetchProfile(tokenPayload): Promise<IOAuthProfile>`: takes the token payload returned from the `callback()` method
  and returns the profile data. Although each provider returns different data, they are all pre-configured in this
  library to return the `IOAuthProfile` described below.

```typescript
export interface IOAuthProfile {
	id?: string
	email?: string
	emailVerified?: boolean
	first?: string
	last?: string
	avatar?: string
	raw: any
}
```

Where `raw` is the raw JSON-parsed data returned from the provider. Other fields are calculated **carefully** based on
the data returned from the provider.

## Customized provider

While I recommend you using the pre-configured providers, you can also create your own customized provider by extending
the `OAuth`/`OAuth2` classes or initialize a new instance of the `OAuth`/`OAuth2` classes directly.

Here are two sample implementations of `FacebookAuthenticator` (extending `OAuth2`), and `TwitterAuthenticator` (
extending `OAuth`)

```typescript
class FacebookAuthenticator
	extends OAuth2<IFacebookTokenPayload>
	implements IOAuthProfileFetcher<IFacebookTokenPayload> {
	fetchProfile = fetchFacebookProfile

	constructor(options: {
		clientID: string
		clientSecret: string
		redirectUri: string
		scope?: string
	}) {
		super({
			consentURL: 'https://www.facebook.com/v9.0/dialog/oauth',
			tokenURL: 'https://graph.facebook.com/v9.0/oauth/access_token',
			scope: ['email'].join(','),
			...options,
		}, {
			ignoreGrantType: true,
			tokenRequestMethod: TokenRequestMethod.GET,
			includeStateInAccessToken: false,
			enablePKCE: false,
		})
	}
}

export default class TwitterAuthenticator extends OAuth implements IOAuthProfileFetcher<IOAuthTokenPayload> {
	constructor(config: {
		clientID: string
		clientSecret: string
		redirectUri: string
	}) {
		super({
			consumerKey: config.clientID,
			consumerSecret: config.clientSecret,
			callbackUrl: config.redirectUri,
			requestTokenUrl: 'https://api.twitter.com/oauth/request_token',
			accessTokenUrl: 'https://api.twitter.com/oauth/access_token',
			authorizeUrl: 'https://api.twitter.com/oauth/authorize',
			signingMethod: OAuthSigningMethod.Hmac,
		})
	}

	async fetchProfile(tokenPayload: IOAuthTokenPayload) {
		const response = await this.signAndFetch(
			'https://api.twitter.com/1.1/account/verify_credentials.json',
			{
				qs: {include_email: true},
			},
			tokenPayload
		)
		if (!response.ok) throw new OAuthProfileError(await response.text())
		const profile = await response.json()
		if (!profile.id_str) throw new OAuthProfileError('Invalid Twitter profile ID')
		return {
			id: profile.id_str,
			raw: profile,
			avatar: profile.profile_image_url_https
				|| profile.profile_image_url
				|| profile.profile_background_image_url_https
				|| profile.profile_background_image_url,
			first: profile.name || profile.screen_name,
			email: profile.email,
			emailVerified: !!profile.email,
			/**
			 * from twitter docs
			 * https://developer.twitter.com/en/docs/accounts-and-users
			 * /manage-account-settings/api-reference/get-account-verify_credentials
			 * When set to true email will be returned in the user objects as a string.
			 * If the user does not have an email address on their account,
			 * or if the email address is not verified, null will be returned.
			 */
		}
	}
}
```

