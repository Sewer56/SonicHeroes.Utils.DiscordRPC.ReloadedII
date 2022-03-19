# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

./Publish.ps1 -ProjectPath "sonicheroes.utils.discordrpc/sonicheroes.utils.discordrpc.csproj" `
              -PackageName "sonicheroes.utils.discordrpc" `
              -PublishOutputDir "Publish/ToUpload" `

Pop-Location