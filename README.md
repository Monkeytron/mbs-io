# mbs-io
***
A c# translation of the code to read and write mbs files for stencyl.
Based off the code in [haxe-mbs](https://github.com/Stencyl/haxe-mbs) and [stencyl-engine](https://github.com/Stencyl/stencyl-engine).
This code is capable of reading certain .mbs files from stencyl games, editing them, and then saving them in the stencyl compatible .mbs format.

Currently this contains:
- Core mbs types in src/mbs
- Some of the derived mbs types stencyl uses in src/stencyl/io/mbs
- Classes that can be used to store and edit the mbs data in src/stencyl
- An example of how to read and write a scene .mbs file in src/program.cs
- An example of how to read a behaviors.mbs file in src/program.cs

To edit .mbs files more easily, I recommend you use [MbsEditor](https://github.com/Monkeytron/MbsEditor) .

## Planned improvements:
- Expand the type library to be able to fully read all .mbs files used by stencyl (not just scene and behavior files).

## Possible improvements:
- Improve efficiency (this creates larger files for the same amount of raw game data stored than the stencyl engine.
    This may cause problems for the 5MB+ resources.mbs files if not improved.
