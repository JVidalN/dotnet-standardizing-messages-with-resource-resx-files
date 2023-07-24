# Project Title

## Introduction

This project is a .NET WebAPI project that demonstrates how to use resources (resx) files to provide messages for validations and errors. The objective is to centralize the error and validation messages in resource files, standardize the messages and making it easier to manage.

## Article
I have written an article explaining the implementation details of this project. You can find the article [here](https://dev.to/jvidaln/standardizing-validation-and-error-messages-using-resource-resx-files-in-net-2c9p "Standardizing validation and error messages using Resource (.resx) files in .NET").

## Getting Started

### Prerequisites
* .NET 7 SDK
* Visual Studio Code (or any other preferred code editor)

### Clone the Repository

Clone this repository to your local machine using the following command:

```
git clone https://github.com/JVidalN/dotnet-standardizing-messages-with-resource-resx-files.git
```

### Build and Run the Project
1. Open the project in Visual Studio Code (or your preferred code editor).
2. Restore the dependencies and build the project:

```
dotnet restore
dotnet build
```

### Run the project:

```
dotnet run
```

The API will start running at **`https://localhost:5001`** (or **`http://localhost:5000`** for HTTP) by default.

### Commands Used To Create The Project

1. Create the .NET solution file using the following command:
`dotnet new sln -n ResourceResx`

2. Create the project:
`dotnet new webapi -n WebApiResource`

3. Add the created project to the solution:
`dotnet sln add WebApiResource/WebApiResource.csproj`

## Resource Files

The project contains two resource files located in the `Resources` folder:

1. **`ErrorMessages.resx`**: Contains error messages with HTTP status codes as keys and corresponding error messages as values. This allows us to easily return standard error messages for specific HTTP status codes.

2. **`ValidationMessages.resx`**: Contains validation messages with keys such as "Required", "Email", "Length", etc., which are used for annotating the model properties in the `User` model.

## How It Works

The project demonstrates how to use the resource files to provide error and validation messages in the API.

To understand in more detail how it works and the idea, read the article I made. Article link in the Article section above.

## Contributing

Contributions to this project are welcome! 
If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.
