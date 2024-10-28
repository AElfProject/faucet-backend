# AElf Faucet Backend

The AElf Faucet Backend is a service designed to provide users with test tokens on the AElf blockchain network. This service is primarily intended for developers who need test tokens for development and testing purposes.

## Table of Contents

- [AElf Faucet Backend](#aelf-faucet-backend)
    - [Table of Contents](#table-of-contents)
    - [Overview](#overview)
    - [Features](#features)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
    - [Configuration](#configuration)
    - [Usage](#usage)
    - [Contributing](#contributing)
    - [License](#license)

## Overview

This project implements a backend service that allows users to request test tokens from an AElf testnet faucet. It includes endpoints for claiming tokens and verifying eligibility based on various criteria.

## Features

- Claim test tokens
- Verification of eligibility
- Logging and monitoring
- Easy configuration and deployment

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or later)
- [AElf SDK](https://github.com/AElfProject/AElf)

## Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/AElfProject/faucet-backend.git
    cd faucet-backend
    ```

2. Restore the dependencies:
    ```bash
    dotnet restore
    ```

3. Build the project:
    ```bash
    dotnet build
    ```

## Configuration

Create a `appsettings.json` file in the AELFFaucet.Web directory of the project with the following content:

```json
{
  "App": {
    "AllowedHosts": "*",
    "CorsOrigins": "*"
  },
  "ConnectionStrings": {
    "Default": "mongodb://localhost:27017/SendTokenDB"
  },
  "Kestrel": {
    "EndPoints": {
      "Http": {
        "Url": "http://*:8801/"
      }
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "System": "Error",
      "Microsoft": "Error"
    }
  }
}
```

## Setup secrets.json file

Run this following command in terminal of the AELFFaucet.Web directory to generate the secrets.json file with all ENV keys: 

```base title="Terminal"
dotnet user-secrets init
dotnet user-secrets set "ApiConfig:BaseUrl" "http://3.25.10.185:8000"
dotnet user-secrets set "ApiConfig:PrivateKey" "b192e307da4c4e1a00eeed442a4b5e8e0b7b2c6f838d0472627b846e5280c51c"
dotnet user-secrets set "ApiConfig:NftSeedPrivateKey" "97a1747af1539a6b839c92227c8f5ca90ef0e7de70e5c2f46c64f27b12fabdd7"
dotnet user-secrets set "ApiConfig:BaseUrlForMainchain" "https://aelf-test-node.aelf.io"
dotnet user-secrets set "ApiConfig:BaseUrlForSidechain" "https://tdvw-test-node.aelf.io"
dotnet user-secrets set "ApiConfig:SendCount" "100"
dotnet user-secrets set "ApiConfig:RecaptchaVerifyUrl" "https://www.google.com/recaptcha/api/siteverify"
dotnet user-secrets set "ApiConfig:FaucetUI" "6LcovGQqAAAAAO3AI_xiH1C_m9D7LGPwKVQKxcEW"
dotnet user-secrets set "ApiConfig:Playground" "6LfgxmQqAAAAADPdRxWA_KMRMPNLCV9XlI-rnKGK"
dotnet user-secrets set "ApiConfig:AelfStudio" "6LfkxmQqAAAAABg622JHjULYqrSLE7JQa6Q_UXyr"
```
 
Replace the PrivateKey and NftSeedPrivateKey with your actual AElf testnet node private keys for storing token pool for token distribution.

## Usage
Run the service:

```bash
dotnet run
```
The service will be available at http://localhost:8801.
You can access the swagger documentation at http://localhost:8801/swagger/index.html.

## Contributing
Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

