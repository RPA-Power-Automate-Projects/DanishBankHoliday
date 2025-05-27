# DanishBankHoliday

## Steps:
### 1. Create Project
  * Open Microsoft Visual Studio (Install Workloads .NET Desktop Development)
  * Create a new project > Search Template "Class Library (.NET Framework)" for C# > Click Next
  * Give Project Name > Select Framework .NET Framework 4.7.2 > Choose Project Location > Click Create

### 2. Install PAD Package
  * Solution Explorer > Right click > Click Manage Nuget Packages for SOlution
  * Install "Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK" package (Also make sure "Newtonsoft.Json" is installed)

### 3. Write code
  * Refer to Reference docs to write code for Custom Action
  * Rename .cs class name
    
### 4. Release and Build
  * Select "Release" from Debug
  * Build > Rebuild Solution
  * Goto project folder and find Release subfolder (You can also get it from Build output)
  * Following files will be present in Release Sub Folder "<ProjectName>.dll", "Microsoft.PowerPlatform.PowerAutomate.Desktop.Actions.SDK.dll" and "Newtonsoft.Json.dll"
  * Rename "<ProjectName>.dll" to "Modules.<ProjectName>.dll"
    
### 5. Create Certificate (Scripts availabe at \Shell Scripts\Create Certificate\CreateAndExportCert.ps1)
  * Open script in notepad > Replace <PASSWORD> with your value (Will be used later) > Replace <OUTPUT_PATH> with path where you want to store certificate file(PaCustomActionsCert.pfx)
  * Open PowerShell > execute "CreateAndExportCert.ps1" script (PaCustomActionsCert.pfx file will be created at given output path)
  * Add to trusted certificate in windows: certmgr > Trusted Root Certification Authorities > Certificates > Right Click > All Tasks > Import > Add file path "PaCustomActionsCert.pfx" > Click Next

### 6. Sign dll files with certificates
  * Write command for all three .dll files "Signtool sign /f <CERTIFICATE_FILE_PATH> /p <PASSWORD> /fd SHA256 <DLL_FILE_PATH>". Example: \Steps\Sign all dll files.txt
  * Add Signtool.exe file path to System Environment Variable 'Path' ans restart Visual Studio
  * Goto "Visual Studio > Tools > Command Line > Developer Command Prompt" and enterl all three commands here one by one

### 7. Compress to Cab file
  * In PowerShell execute \Shell Scripts\CabCompression.ps1 script. (.\CabCompression.ps1 <REALESE_FOLDER_PATH> <CAB_OUTPUT_PATH> MyCustomActions.cab)
  * MyCustomActions.cab file will be created

### 8. Sign the Cabinet file
  * Sign the .cab file with same as #6 "Signtool sign /f <CERTIFICATE_FILE_PATH> /p <PASSWORD> /fd SHA256 <CAB_FILE_PATH>" from Visual Studio command prompt

### 9. Upload to Power Automate
  * goto https://make.powerautomate.com > Custom Actions
  * Upload Signed Cabinet file with Category Name


## Reference docs: 
https://github.com/MicrosoftDocs/power-automate-docs/blob/main/articles/desktop-flows/create-custom-actions.md
