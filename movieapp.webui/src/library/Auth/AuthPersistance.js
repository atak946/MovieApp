import SecureLS from "secure-ls";

var secureStorage = new SecureLS({ encodingType: 'aes', isCompression: true, encryptionSecret: '7Jh8~[m(5J%d"v%5' });

export default secureStorage;