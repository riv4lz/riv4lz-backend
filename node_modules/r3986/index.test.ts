import 'regenerator-runtime'
import rfc3986 from './index'

describe('rfc3986', () => {
  test('should encode ASCII correctly', async () => {
  	const exceptions = {
  		'!': '%21',
			'\'': '%27',
			'(': '%28',
			')': '%29',
			'*': '%2a'
		} as any
  	for(const code of new Array(128).keys()) {
			const char = String.fromCharCode(code)
			expect(rfc3986(char).toUpperCase()).toBe((exceptions[char] || encodeURIComponent(char)).toUpperCase())
		}
  })
})
