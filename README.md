# Minecraft Map Transfer

Moving minecraft server map files could be easy.

# How to run

1. Prepare block coordinates file, format like this:

   ```
   -1204,192
   -1358,-120
   -434,654
   -422,988
   -104,326
   ```

   First one is `x`, Second one is `z`.

2. Just adapt the values in `config.py`

   ```python
   block_coordinate_file_path = "C:\\Users\\cdcd7\\Desktop\\mc-map-block-coordinates.txt"
   minecraft_world_source_directory_path = "C:\\Users\\cdcd7\\Desktop\\world"
   minecraft_world_destination_directory_path = "C:\\Users\\cdcd7\\Desktop\\newWorld"
   minecraft_world_scan_directory_names = ["region", "entities", "poi"]
   ```

3. Run the script

   ```
   py minecraft_map_transfer.py
   ```

   you well see under message, like this:

   ```
   Block coordinate: -1204,192
    => Region coordinate: -3,0
   Block coordinate: -1358,-120
    => Region coordinate: -3,-1
   Block coordinate: -434,654
    => Region coordinate: -1,1
   Block coordinate: -422,988
    => Region coordinate: -1,1
   Block coordinate: -104,326
    => Region coordinate: -1,0
   Currently copy old world files to new world folder...
   Source file: C:\Users\cdcd7\Desktop\world\region\r.-3.0.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\region\r.-3.0.mca
   Source file: C:\Users\cdcd7\Desktop\world\region\r.-3.-1.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\region\r.-3.-1.mca
   Source file: C:\Users\cdcd7\Desktop\world\region\r.-1.1.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\region\r.-1.1.mca
   Source file: C:\Users\cdcd7\Desktop\world\region\r.-1.0.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\region\r.-1.0.mca
   Source file: C:\Users\cdcd7\Desktop\world\entities\r.-3.0.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\entities\r.-3.0.mca
   Source file: C:\Users\cdcd7\Desktop\world\entities\r.-3.-1.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\entities\r.-3.-1.mca
   Source file: C:\Users\cdcd7\Desktop\world\entities\r.-1.1.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\entities\r.-1.1.mca
   Source file: C:\Users\cdcd7\Desktop\world\entities\r.-1.0.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\entities\r.-1.0.mca
   Source file: C:\Users\cdcd7\Desktop\world\poi\r.-3.0.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\poi\r.-3.0.mca
   Source file: C:\Users\cdcd7\Desktop\world\poi\r.-3.-1.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\poi\r.-3.-1.mca
   Source file: C:\Users\cdcd7\Desktop\world\poi\r.-1.1.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\poi\r.-1.1.mca
   Source file: C:\Users\cdcd7\Desktop\world\poi\r.-1.0.mca => Destination file: C:\Users\cdcd7\Desktop\newWorld\poi\r.-1.0.mca
   Copy old world files to new world folder complete.
   ```

# Reference

- https://github.com/sebkuip/minecraft-region-calculator
