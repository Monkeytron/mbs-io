using System;
using System.IO;
using System.Xml;
using System.Linq;

using haxe_mbs_translate.src.mbs.io;
using haxe_mbs_translate.src.mbs.core;
using haxe_mbs_translate.src.mbs.core.header;

using MiscUtil.Conversion;

using haxe_mbs_translate.src.stencyl.io.mbs.scene;
using haxe_mbs_translate.src.stencyl.io.mbs.snippet;
using haxe_mbs_translate.src.stencyl.io.mbs.scene.physics;
using haxe_mbs_translate.src.stencyl.io.mbs.shape;
using haxe_mbs_translate.src.stencyl.behavior;
using haxe_mbs_translate.src.stencyl.models.scene;
using haxe_mbs_translate.src.stencyl.io.mbs.scene.layers;
using haxe_mbs_translate.src.stencyl.models;
using System.Drawing;


/*
 * How to read a list:
 * Make a new Mbs<Whatever>List().
 * setAddress() - this handles getting the length, type, etc
 * readObject() as many times as the length (and no more!)
 * getNextObject() for List<T> uses the same instance of T, so it overwrites it each call.
 * */

/*
 * How to write a list:
 * Make a new MbsList().
 * allocateNew(Number of objects) - Makes 2 ints for length and type, and then enough space for every object there.
 * The data written as the field is getAddress().
 * 
 * Then, for each object in the list:
 * getNextObject() to return the MbsObject - no need to allocate new for this as there is already space and an address allocated by the list.
 * write everything in with that object.
 * 
 * If it's a dynamic list:
 * first, initialise the object to be written (and allocate it if it is an MbsObject)
 * All the data for that mbsobject does not have to be written yet, but it can be.
 * Then, writeObject(o) in the list.
 * 
 * All other lists allocate enough space within the list for every object.
 * However, dynamic lists don't (just enough space to write type and address) so each object must be allocated seperately.
 * Obviously, if an object contains pointers to other objects those objects also have to be allocated.
 * */


namespace haxe_mbs_translate.src
{
    class Program
    {
        static void Main()
        {
            // An example of how to use the code to read an mbs file. This specific code only works with scene-{id}.mbs currently.

            MbsReader reader = new MbsReader(MbsVersionControl.ALLCURRENTVERSIONS, false, true);

            Byte[] bytes = File.ReadAllBytes(Console.ReadLine());

            reader.readData(bytes);

            MbsScene r = reader.getRoot();

            Scene s = Scene.FromMbs(r);

            Console.WriteLine($"Successfully read scene {s.id} \"{s.name}\"");
            Console.WriteLine(s.ToString(true, true, true, true, true));

            // Reading code finished.


            /*
             * Data editing code can be added here.
            */

            // Writing code

            MbsWriter w = new MbsWriter(MbsVersionControl.DADISH.Item2, false, MbsVersionControl.DADISH.Item1);

            MbsScene writeTo = new MbsScene(w);

            writeTo.allocateNew();

            s.WriteMbs(writeTo, false);

            w.setRoot(writeTo);

            w.prepareForOutput();

            w.writeToFile("scene-test.mbs");

            // Writing code finished.

            Console.WriteLine($"Successfully written scene {s.id} \"{s.name}\"");

            Console.ReadLine();
        }
    }
}
