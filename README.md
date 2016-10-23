# EWSMailboxItemMoverWPF
A C# application that uses the Microsoft EWS API to run rules against Exchange mailboxes in a similar way to Outlook, but without the rule limits.
The aim is to build a windows service that can connect to a mailbox at an interval and process rules which are defined in JSON.
A seperate rules editor will be created to assist in the creation of the JSON files
