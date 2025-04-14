ARG SERVER_VERSION='ltsc2022'  
FROM mcr.microsoft.com/windows/servercore:${SERVER_VERSION}

RUN powershell Invoke-WebRequest 'https://fastdl.mongodb.org/windows/mongodb-windows-x86_64-8.0.6-signed.msi' -OutFile 'c:\mongodb-windows-x86_64-8.0.6-signed.msi'
RUN msiexec.exe /q /i c:\mongodb-windows-x86_64-8.0.6-signed.msi SHOULD_INSTALL_COMPASS="0"

EXPOSE 27017


