import os
import shutil
from config import *


def to_region_coordinate(block_coordinate):
    split_block_coordinate = block_coordinate.split(",")
    x = int(split_block_coordinate[0])
    z = int(split_block_coordinate[1])
    return f"{x//512},{z//512}"


region_coordinates = []

# Block coordinate to region coordinate.
with open(block_coordinate_file_path, "r") as f:
    block_coordinates = f.readlines()
    for block_coordinate in block_coordinates:
        region_coordinate = to_region_coordinate(block_coordinate)
        print(
            f"Block coordinate: {block_coordinate} => Region coordinate: {region_coordinate}"
        )
        if not (region_coordinate in region_coordinates):
            region_coordinates.append(region_coordinate)

print("Currently copy old world files to new world folder...")

# Copy mca files from old world to new world according to region coordinate.
for scanned_directory_name in minecraft_world_scan_directory_names:
    source_directory_path = os.path.join(
        minecraft_world_source_directory_path, scanned_directory_name
    )
    destination_directory_path = os.path.join(
        minecraft_world_destination_directory_path, scanned_directory_name
    )
    if not (os.path.exists(source_directory_path)):
        continue
    for region_coordinate in region_coordinates:
        file_name = f"r.{region_coordinate.replace(',', '.')}.mca"
        source_file_path = os.path.join(source_directory_path, file_name)
        destination_file_path = os.path.join(destination_directory_path, file_name)
        if not (os.path.exists(source_file_path)):
            continue
        if not (os.path.exists(destination_directory_path)):
            os.makedirs(destination_directory_path)
        print(
            f"Source file: {source_file_path} => Destination file: {destination_file_path}"
        )
        shutil.copy(source_file_path, destination_file_path)

print("Copy old world files to new world folder complete.")
