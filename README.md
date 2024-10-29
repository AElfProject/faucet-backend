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
dotnet user-secrets set "ApiConfig:PrivateKey" "b192e30XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX280c51c"
dotnet user-secrets set "ApiConfig:NftSeedPrivateKey" "97a1747XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX12fabdd7"
dotnet user-secrets set "ApiConfig:FaucetUI" "6LcovXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXKxcEW"
dotnet user-secrets set "ApiConfig:Playground" "6LfgxXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXrnKGK"
dotnet user-secrets set "ApiConfig:AelfStudio" "6LfkxXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX_UXyr"
```
 
Replace the Value of all keys with your actual values for storing token pool for token distribution.

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

