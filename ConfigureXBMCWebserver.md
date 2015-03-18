## XBMC Webserver configuration ##
In XBMC go to "Settings" -> "Network". One of the options presented is "Server" (second option with the PMIII skin) where you can enable/disable the "Webserver". The webserver must be enabled to be able to use XBMControl.

### Port ###
You can configure a custom port if you want or need to. If you already have running a webserver on the XBMC host, port 80 will be occupied and you will need to configure a different prot for either XBMC webserver or your other webserver. If you change the port in XBMC it should be configured accordingly in XBMControl. Suppose your XBMC host ip is 192.168.1.100 and the port you've configured for the XBMC webserver is 8080, ip XBMControl you should enter in the "address field" -> "192.168.1.100:8080". If you leave the XBMC webserver port untouched (it stays at "80") you won't need to a configure a port in XBMControl. Simply entering "192.168.1.100" in the ip address field will be sufficient since port 80 is the default http port and all applications assume that, when no port is configured, port 80 is intended to be used.

### Password ###
If you don't configure a password in the "Servers" screen in XBMC, no credentials are required. If you do choose to use a password the default username will be "xbox" and the password "yourpassword".