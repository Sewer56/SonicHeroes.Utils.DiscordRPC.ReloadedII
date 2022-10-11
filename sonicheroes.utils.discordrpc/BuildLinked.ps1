# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/SonicHeroes.Utils.DiscordRPC/*" -Force -Recurse
dotnet publish "./SonicHeroes.Utils.DiscordRPC.csproj" -c Release -o "$env:RELOADEDIIMODS/SonicHeroes.Utils.DiscordRPC" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location