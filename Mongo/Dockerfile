FROM mcr.microsoft.com/windows/server:ltsc2022 AS base

RUN powershell "(New-Object System.Net.WebClient).DownloadFile('https://fastdl.mongodb.org/windows/mongodb-windows-x86_64-8.0.6-signed.msi', 'c:\temp\mongodb-windows-x86_64-8.0.6-signed.msi')"
RUN msiexec.exe /q /i c:\temp\mongodb-windows-x86_64-8.0.6-signed.msi SHOULD_INSTALL_COMPASS="0"


