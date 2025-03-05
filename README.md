# OpenAPI-2-Excel

<div align="center">
    <img src="assets/logo.png" width="250px">
</div>

<div align="center">

[![🚧 - Under Development](https://img.shields.io/badge/🚧-Under_Development-orange)](https://)
[![NuGet Package](https://img.shields.io/badge/.NET%20-8.0-blue.svg)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![NuGet Package](https://img.shields.io/badge/Nugets-2ea44f?logo=nuget)](https://www.nuget.org/packages/openapi2excel.cli/)
[![GitHub license](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/pszybiak/openapi-2-excel/blob/main/LICENSE.md)

</div>

Tool to generate Rest API specification in a MS Excel format - human friendly document from Swagger/OpenAPI spec in YAML or JSON. The result should be accessible to Business Analyst and software developers.

> \[!NOTE]
>
> This project is part of the ["100 Commits"](https://100commitow.pl/) competition, whose main purpose is is to develop an original Open Source project for 100 days.
>

## Installation

Download and install the one of the currently supported [.NET SDKs](https://www.microsoft.com/net/download). Once installed, run the following command:

```bash
dotnet tool install --global openapi2excel.cli
```

## Usage

<div align="center">
    <img src="assets/usage.png" width="90%">
</div>

Example
```text
  openapi2excel C:\openapi-spec.yml C:\openapi-spec.xlsx
```

## Result

To show how the application works, let's use the official example used on the [Swagger Editor website](https://editor.swagger.io/).

```
  openapi2excel https://raw.githubusercontent.com/swagger-api/swagger-petstore/master/src/main/resources/openapi.yaml C:\openapi.xlsx
```

The first tab is an information tab, presenting document details and a list of available operations.

<div align="center">
    <img src="assets/info_worksheet.png" width="90%">
</div>

The next tabs contain details of individual operation.

<div align="center">
    <img src="assets/operation_details.png" width="90%">
</div>



## Wrap Up

If you think the repository can be improved, please open a PR with any updates and submit any issues.

## Contribution

- Open a pull request with improvements
- Discuss ideas in issues


## Required

- OpenAPI(Swagger) 문서 버전 3.0.X


## Re Build And ReInstall

---

## **1. 기존 `openapi2excel.cli` 제거**
먼저 기존에 설치된 CLI 도구를 삭제해야 변경 사항이 반영

```sh
dotnet tool uninstall --global openapi2excel.cli
```

---

## **2. 코드 수정 후 빌드**

### **2.1 프로젝트 폴더로 이동**
```sh
cd /path/to/openapi2excel.cli
```
`openapi2excel.cli`의 프로젝트 루트 디렉토리로 이동

### **2.2 의존성 복원**
```sh
dotnet restore
```
필요한 패키지를 최신 상태로 가져옴

### **2.3 빌드 실행**
```sh
dotnet build --configuration Release
```
`Release` 모드로 빌드해서 최적화된 실행 파일을 만듬

---

## **3. `.nupkg` 패키지 생성**
전역 설치가 필요한 CLI 도구이므로, `.nupkg` 패키지를 만들어야 해.

```sh
dotnet pack --configuration Release --output ./nupkg
```
`./nupkg` 폴더 안에 `.nupkg` 파일이 생성

---

## **4. 수정된 패키지를 전역 도구로 설치**
이제 수정된 `openapi2excel.cli`를 다시 설치

```sh
dotnet tool install --global --add-source ./nupkg openapi2excel.cli
```
`--add-source ./nupkg` 옵션을 사용해서 **로컬에서 빌드한 패키지를 전역 설치**

---

## **5. 설치 확인**
제대로 설치되었는지 확인하려면 다음 명령어를 실행

```sh
dotnet tool list --global
```
`openapi2excel.cli`가 설치된 목록에 나오면 성공

---

## **6. 실행 테스트**
```sh
openapi2excel --help
```
또는 실제 OpenAPI 스펙을 변환해서 테스트:

```sh
openapi2excel C:\openapi-spec.yml C:\openapi-spec.xlsx
```

---

## **최종 정리**
**기존 도구 삭제**
   ```sh
   dotnet tool uninstall --global openapi2excel.cli
   ```

**코드 수정 후 빌드**
   ```sh
   dotnet restore
   dotnet build --configuration Release
   ```

**패키지 생성 (`.nupkg`)**
   ```sh
   dotnet pack --configuration Release --output ./nupkg
   ```

**새 패키지 전역 설치**
   ```sh
   dotnet tool install --global --add-source ./nupkg openapi2excel.cli
   ```

**설치 확인 및 실행 테스트**
   ```sh
   dotnet tool list --global
   openapi2excel --help
   ```


## License

[![GitHub license](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/pszybiak/openapi-2-excel/blob/main/LICENSE.md)