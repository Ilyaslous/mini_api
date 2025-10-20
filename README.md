# Project: Data Signing API (.NET 8)

This is a technical demonstration project inspired by the real-world business needs of companies specializing in digital content certification.

**Goal:** To implement a Proof of Concept (PoC) for a data signing API using C# / .NET 8. The project focuses on the core concepts of data authenticity and verification (PKI, X.509).

---

## Features

This API exposes two primary endpoints:

### 1. `POST /api/signing/sign`
Digitally signs a piece of content (an author + a message) using a self-signed X.509 certificate.

**Example Request (Body):**
```json
{
  "auth": "MyAuthor",
  "msg": "This is my original content"
}
Example Response (Body):

JSON

{
  "originalData": {
    "auth": "MyAuthor",
    "msg": "This is my original content"
  },
  "signature": "vBPX6wAputu0VUVK792aFdnDGdueEpBotUIkih31ICKD6PozF1MnFTBSsoxrvOjtx+gdpt2o5Jlso4uYADyppc2O2UaxEGwEd+C1Ul6jY9gqy5o4sbpyBF+c2ESHcj51RoXAxdJA58fVdeBmTSfFvSUbOJyTd7OeYXbFRHm+bVaR8aDMG/D3aRteOSWVfO3pJNG8MCybnxq0Qrho7ORDVzFmSWVMn+FVG/POHQ6ENPDbrBFynPwYbLxlnL9/e4160LERsk+ICF2SohxoWKs1baFMgUZsdzpQdKurTolkwFP7+eBciNo95vViuGIA25RUc63hb/IogHhWm6IkppLxmA=="
}
2. POST /api/signing/verify
Example Request (Body):

JSON

{
    "auth": "MyAuthor",
    "msg": "This is my original content",
    "sig":"vBPX6wAputu0VUVK792aFdnDGdueEpBotUIkih31ICKD6PozF1MnFTBSsoxrvOjtx+gdpt2o5Jlso4uYADyppc2O2UaxEGwEd+C1Ul6jY9gqy5o4sbpyBF+c2ESHcj51RoXAxdJA58fVdeBmTSfFvSUbOJyTd7OeYXbFRHm+bVaR8aDMG/D3aRteOSWVfO3pJNG8MCybnxq0Qrho7ORDVzFmSWVMn+FVG/POHQ6ENPDbrBFynPwYbLxlnL9/e4160LERsk+ICF2SohxoWKs1baFMgUZsdzpQdKurTolkwFP7+eBciNo95vViuGIA25RUc63hb/IogHhWm6IkppLxmA=="
}
Example Response (Body):

JSON

{
  "originalData": {
    "auth": "MyAuthor",
    "msg": "This is my original content",
    "sig": "vBPX6wAputu0VUVK792aFdnDGdueEpBotUIkih31ICKD6PozF1MnFTBSsoxrvOjtx+gdpt2o5Jlso4uYADyppc2O2UaxEGwEd+C1Ul6jY9gqy5o4sbpyBF+c2ESHcj51RoXAxdJA58fVdeBmTSfFvSUbOJyTd7OeYXbFRHm+bVaR8aDMG/D3aRteOSWVfO3pJNG8MCybnxq0Qrho7ORDVzFmSWVMn+FVG/POHQ6ENPDbrBFynPwYbLxlnL9/e4160LERsk+ICF2SohxoWKs1baFMgUZsdzpQdKurTolkwFP7+eBciNo95vViuGIA25RUc63hb/IogHhWm6IkppLxmA=="
  },
  "isValid": true
}
Understanding isValid
The "isValid" field is the result of the cryptographic verification.

"isValid": true: Proves that the signature is authentic and that the auth and msg data have not been changed.

"isValid": false: Means the signature is invalid, which indicates the data was tampered with or the signature is incorrect.
