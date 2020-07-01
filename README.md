# Feuersoftware API-Handler
Eine Clientbibliothek in C# zur Verwendung der öffentlichen Feuersoftware-Connect Schnittstelle. 
Dokumentation der Schnittstelle: https://connectapi.feuersoftware.com/swagger/ui/index

## Verwendung
Die Serviceklasse ApiService muss mit der Basisadresse (standardmäßig: https://connectapi.feuersoftware.com) und dem Bearer-Token initialisiert werden. 
Alle Funktionen sind natürlich asynchron! Daher auch asynchron aufrufen!
