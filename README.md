# Blat_Front-end
My attempt at a C# Blat front-end. http://www.blat.net

## Settings
Added a settings file (application configuration). 5 new settings. Edit *Blat_Front-end.exe.config* to modify settings.
 - **UseRenameZip:** use rename zip function (true/false)
 - **RenameZipExt:** set extension for zip file rename function (ex: z1p, datzip, txt)
 - **UseDefaultFromEmailAddress:** use the specified "DefaultFromEmailAddress" value (true/false)
 - **DefaultFromEmailAddress:** set the value for use as the From email address (ex: jack@smith.com)
 - **DisableFromEmailAddressField:** Disables the From email address field text box (true = disabled/false = enabled)

Also, create a `contacts.lst` file with first/last names and email addresses, and the emails will autocomplete as you type into the Recipient field. See the included `contacts.lst` file.
