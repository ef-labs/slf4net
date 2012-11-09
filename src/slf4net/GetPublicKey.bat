@ECHO OFF
SET sn="C:\Program Files\Microsoft SDKs\Windows\v6.0A\Bin\sn.exe"
%sn% -p slf4net.snk slf4net.PublicKey
%sn% -tp slf4net.PublicKey
PAUSE