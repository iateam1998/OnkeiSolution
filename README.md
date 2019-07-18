# UbuntuServerDotnet
> LuanDNH
## This shell is used for install dotnet core on server ubuntu and install sqlmap and nmap

1. Register Microsoft key and feed
    ```
    wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    ```
2. Install the .NET SDK
    ```
    sudo add-apt-repository universe
    sudo apt-get install apt-transport-https -y
    sudo apt-get update
    sudo apt-get install dotnet-sdk-2.2=2.2.203-1 -y
    ```
3. Install nmap
    ```
    sudo apt-get update
    sudo apt-get install nmap -y
    ```
4. Install sqlmap
    ```
    sudo apt-get install python2.7 -y
    sudo apt-get update
    sudo apt-get install sqlmap -y
    ```    
5. Publish project OnkeiSolution
    ```
    cd OnkeiSolution/
    mkdir PublishSolution
    dotnet publish OnkeiSolution/OnkeiSolution.csproj --framework netcoreapp2.2 --output PublishSolution/
    ```
6. Run project OnkeiSolution
    ```
    cd PublishSolution
    dotnet /OnkeiSolution.dll
    ```
