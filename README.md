# DW2 xml name editor

1. Select .xml file
2. Scan file
---1. Array object ID text field - should automatically detect the xml id element name, otwerise just put name of the element that holds id
---2. Array object Name text field - Usually is "Name", although you could use any other element value name to replace besides the name
3. Extract dictionary - Extracts the dictionary from the xml file that contains ID and Name values and displays it to the right datagrid
4. Upload dictionary - Imports previosly prepared dictionary
5. Export dictionary - Exports what ever is displayed in the data grid into a later usable dictionary. Usefull to maintain so that when updates happen, new renaming can be done quickly without touching any other values but the name. Avoiding overwrtinig what is new with old.
6. Merge - Merges the dictionary displayed in the grid field with the selected file, without overwriting original instead promting to save the combined file with a new name in chosen directory.
