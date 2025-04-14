FROM mcr.microsoft.com/windows/server:ltsc2022 AS base

RUN powershell Invoke-WebRequest 'https://fastdl.mongodb.org/windows/mongodb-windows-x86_64-8.0.6-signed.msi' -OutFile 'c:\temp\mongodb-windows-x86_64-8.0.6-signed.msi'
RUN msiexec.exe /q /i c:\temp\mongodb-windows-x86_64-8.0.6-signed.msi SHOULD_INSTALL_COMPASS="0"


