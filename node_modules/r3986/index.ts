/*
 * RFC3986: https://tools.ietf.org/html/rfc3986
 * 2.1 Percent-Encoding
 * 2.1.  Percent-Encoding
 *    The uppercase hexadecimal digits 'A' through 'F' are equivalent to
   the lowercase digits 'a' through 'f', respectively.  If two URIs
   differ only in the case of hexadecimal digits used in percent-encoded
   octets, they are equivalent.  For consistency, URI producers and
   normalizers should use uppercase hexadecimal digits for all percent-
   encodings.
 */
export default (plain: string) => encodeURIComponent(plain)
	.replace(/[!'()*]/g, c => `%${c.charCodeAt(0).toString(16).toUpperCase()}`)
