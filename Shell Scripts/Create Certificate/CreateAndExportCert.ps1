$certname = "PaCustomActionsCert"
$cert = New-SelfSignedCertificate -Type "CodeSigningCert" -Subject "CN=$certname" -CertStoreLocation "Cert:\CurrentUser\My" -KeyExportPolicy Exportable -KeySpec Signature -KeyLength 2048 -KeyAlgorithm RSA -HashAlgorithm SHA256
$password = ConvertTo-SecureString '<PASSWORD>' -AsPlainText -Force
Export-Certificate -Cert $cert -FilePath "<OUTPUT_PATH>$certname.pfx"