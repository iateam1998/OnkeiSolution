#!/bin/bash

#Register Microsoft key and feed
wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb

#Install the .NET SDK
sudo add-apt-repository universe
sudo apt-get install apt-transport-https -y
sudo apt-get update
sudo apt-get install dotnet-sdk-2.2=2.2.203-1 -y

#Install nmap
sudo apt-get update
sudo apt-get install nmap -y

#Install sqlmap
sudo apt-get install python2.7 -y
sudo apt-get update
sudo apt-get install sqlmap -y


#Publish project OnkeiSolution
cd OnkeiSolution/
mkdir PublishSolution
dotnet publish OnkeiSolution.csproj --framework netcoreapp2.2 --output PublishSolution/

#Run project OnkeiSolution
cd PublishSolution
dotnet ./OnkeiSolution.dll
