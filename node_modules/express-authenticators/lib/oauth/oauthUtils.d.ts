export declare const getTimestamp: () => number;
export declare const getNonce: () => string;
export declare enum OAuthSigningMethod {
    Hmac = "HMAC-SHA1",
    Plain = "PLAINTEXT",
    Rsa = "RSA-SHA1"
}
export declare const oauthSign: (method: OAuthSigningMethod, base: string, consumerSecret: string, tokenSecret?: string | undefined) => string;
