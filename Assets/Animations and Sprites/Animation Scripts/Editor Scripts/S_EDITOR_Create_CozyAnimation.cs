using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class S_EDITOR_Create_CozyAnimation
{
    //info about person animations
    public static ActionAnimationInfo[] infoList = new ActionAnimationInfo[]
    {
        new ActionAnimationInfo("axe", 5, false, true, 0.01f),
        new ActionAnimationInfo("block", 1, false, true, 0.01f),
        new ActionAnimationInfo("carry", 8, false, true, 0.01f),
        new ActionAnimationInfo("die", 2, false, false, 0.01f),
        new ActionAnimationInfo("fishing", 5, false, true, 0.01f),
        new ActionAnimationInfo("hoe", 5, false, true, 0.01f),
        new ActionAnimationInfo("hurt", 1, false, true, 0.01f),
        new ActionAnimationInfo("jump", 5, false, true, 0.01f),
        new ActionAnimationInfo("pickaxe", 5, false, true, 0.01f),
        new ActionAnimationInfo("pickup", 5, false, true, 0.01f),
        new ActionAnimationInfo("sword", 4, false, true, 0.01f),
        new ActionAnimationInfo("walk", 8, true, true, 0.1f),
        new ActionAnimationInfo("water", 2, false, true, 0.01f),
        new ActionAnimationInfo("idle", 1, false, true, 0.01f), //note: uses walk sprites
    };
    //names for all the sprites in order they appear in the spritesheet
    static string[] spriteNames = new string[]
    {
        "walk_down_1",
        "walk_down_2",
        "walk_down_3",
        "walk_down_4",
        "walk_down_5",
        "walk_down_6",
        "walk_down_7",
        "walk_down_8",
        "walk_up_1",
        "walk_up_2",
        "walk_up_3",
        "walk_up_4",
        "walk_up_5",
        "walk_up_6",
        "walk_up_7",
        "walk_up_8",
        "walk_right_1",
        "walk_right_2",
        "walk_right_3",
        "walk_right_4",
        "walk_right_5",
        "walk_right_6",
        "walk_right_7",
        "walk_right_8",
        "walk_left_1",
        "walk_left_2",
        "walk_left_3",
        "walk_left_4",
        "walk_left_5",
        "walk_left_6",
        "walk_left_7",
        "walk_left_8",

        "jump_down_1",
        "jump_down_2",
        "jump_down_3",
        "jump_down_4",
        "jump_down_5",
        "jump_up_1",
        "jump_up_2",
        "jump_up_3",
        "jump_up_4",
        "jump_up_5",
        "jump_right_1",
        "jump_right_2",
        "jump_right_3",
        "jump_right_4",
        "jump_right_5",
        "jump_left_1",
        "jump_left_2",
        "jump_left_3",
        "jump_left_4",
        "jump_left_5",

        "pickup_down_1",
        "pickup_down_2",
        "pickup_down_3",
        "pickup_down_4",
        "pickup_down_5",
        "pickup_up_1",
        "pickup_up_2",
        "pickup_up_3",
        "pickup_up_4",
        "pickup_up_5",
        "pickup_right_1",
        "pickup_right_2",
        "pickup_right_3",
        "pickup_right_4",
        "pickup_right_5",
        "pickup_left_1",
        "pickup_left_2",
        "pickup_left_3",
        "pickup_left_4",
        "pickup_left_5",

        "carry_down_1",
        "carry_down_2",
        "carry_down_3",
        "carry_down_4",
        "carry_down_5",
        "carry_down_6",
        "carry_down_7",
        "carry_down_8",
        "carry_up_1",
        "carry_up_2",
        "carry_up_3",
        "carry_up_4",
        "carry_up_5",
        "carry_up_6",
        "carry_up_7",
        "carry_up_8",
        "carry_right_1",
        "carry_right_2",
        "carry_right_3",
        "carry_right_4",
        "carry_right_5",
        "carry_right_6",
        "carry_right_7",
        "carry_right_8",
        "carry_left_1",
        "carry_left_2",
        "carry_left_3",
        "carry_left_4",
        "carry_left_5",
        "carry_left_6",
        "carry_left_7",
        "carry_left_8",

        "sword_down_1",
        "sword_down_2",
        "sword_down_3",
        "sword_down_4",
        "sword_up_1",
        "sword_up_2",
        "sword_up_3",
        "sword_up_4",
        "sword_right_1",
        "sword_right_2",
        "sword_right_3",
        "sword_right_4",
        "sword_left_1",
        "sword_left_2",
        "sword_left_3",
        "sword_left_4",

        "block_down_1",
        "block_up_1",
        "block_right_1",
        "block_left_1",

        "hurt_down_1",
        "hurt_up_1",
        "hurt_right_1",
        "hurt_left_1",

        "die_1",
        "die_2",

        "pickaxe_down_1",
        "pickaxe_down_2",
        "pickaxe_down_3",
        "pickaxe_down_4",
        "pickaxe_down_5",
        "pickaxe_up_1",
        "pickaxe_up_2",
        "pickaxe_up_3",
        "pickaxe_up_4",
        "pickaxe_up_5",
        "pickaxe_right_1",
        "pickaxe_right_2",
        "pickaxe_right_3",
        "pickaxe_right_4",
        "pickaxe_right_5",
        "pickaxe_left_1",
        "pickaxe_left_2",
        "pickaxe_left_3",
        "pickaxe_left_4",
        "pickaxe_left_5",

        "axe_down_1",
        "axe_down_2",
        "axe_down_3",
        "axe_down_4",
        "axe_down_5",
        "axe_up_1",
        "axe_up_2",
        "axe_up_3",
        "axe_up_4",
        "axe_up_5",
        "axe_right_1",
        "axe_right_2",
        "axe_right_3",
        "axe_right_4",
        "axe_right_5",
        "axe_left_1",
        "axe_left_2",
        "axe_left_3",
        "axe_left_4",
        "axe_left_5",

        "water_down_1",
        "water_down_2",
        "water_up_1",
        "water_up_2",
        "water_right_1",
        "water_right_2",
        "water_left_1",
        "water_left_2",

        "hoe_down_1",
        "hoe_down_2",
        "hoe_down_3",
        "hoe_down_4",
        "hoe_down_5",
        "hoe_up_1",
        "hoe_up_2",
        "hoe_up_3",
        "hoe_up_4",
        "hoe_up_5",
        "hoe_right_1",
        "hoe_right_2",
        "hoe_right_3",
        "hoe_right_4",
        "hoe_right_5",
        "hoe_left_1",
        "hoe_left_2",
        "hoe_left_3",
        "hoe_left_4",
        "hoe_left_5",

        "fishing_down_1",
        "fishing_down_2",
        "fishing_down_3",
        "fishing_down_4",
        "fishing_down_5",
        "fishing_up_1",
        "fishing_up_2",
        "fishing_up_3",
        "fishing_up_4",
        "fishing_up_5",
        "fishing_right_1",
        "fishing_right_2",
        "fishing_right_3",
        "fishing_right_4",
        "fishing_right_5",
        "fishing_left_1",
        "fishing_left_2",
        "fishing_left_3",
        "fishing_left_4",
        "fishing_left_5"
    };

    [MenuItem("Assets/Create/Animations/Batch Cozy Animations Creation")]
    public static void CreateAnimations()
    {
        //get a list of selected objects that are Texture2Ds
        List<Texture2D> selectedTextures = new List<Texture2D>();
        Object[] selectedObjects = Selection.objects;
        foreach(Object obj in selectedObjects)
        {
            Texture2D texture = obj as Texture2D;
            if(texture != null) { selectedTextures.Add(texture); }
        }

        //process textures and store spritesheet textures in a list to create assets from
        List<Texture2D> spritesheets = new List<Texture2D>();
        foreach(Texture2D texture in selectedTextures)
        {
            //ProcessTextures returns null if texture is not a person spritesheet (texture of specific width and height)
            Texture2D spritesheet = ProcessTexture(texture);
            if(spritesheet != null) { spritesheets.Add(spritesheet); }
        }

        //for each selected person spritesheet
        foreach(Texture2D spritesheet in spritesheets)
        {
            //grab texture's name and create folder to store animations
            string spriteSheetName = Path.GetFileNameWithoutExtension(AssetDatabase.GetAssetPath(spritesheet));
            string folderPath = Path.Combine(Path.GetDirectoryName(AssetDatabase.GetAssetPath(spritesheet)), "Animations");
            if(!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }

            //grab this texture's sprites
            Sprite[] sprites = ObjectArrayToSpriteArray(AssetDatabase.LoadAllAssetRepresentationsAtPath(AssetDatabase.GetAssetPath(spritesheet)));

            //for each action, create the proper animations
            foreach(ActionAnimationInfo actionInfo in infoList)
            {
                if(!actionInfo.directional) //nondirectional like die animation
                {   
                    //create and save animation
                    SO_SpriteAnimation anim = ScriptableObject.CreateInstance<SO_SpriteAnimation>();
                    anim = CreateAnimation(sprites, actionInfo.name, actionInfo);
                    SaveAnimation(anim, folderPath, spriteSheetName, actionInfo.name);
                }
                else //all directional animations
                {
                    //action name to search sprites for
                    string spriteActionName = actionInfo.name;
                    if (actionInfo.name == "idle") { spriteActionName = "walk"; } //idle uses walk sprites

                    //create and save animations
                    SO_SpriteAnimation up = ScriptableObject.CreateInstance<SO_SpriteAnimation>();
                    up = CreateAnimation(sprites, spriteActionName, actionInfo, "up");
                    string actionNameWithDirection = actionInfo.name + "_up";
                    SaveAnimation(up, folderPath, spriteSheetName, actionNameWithDirection);

                    SO_SpriteAnimation down = ScriptableObject.CreateInstance<SO_SpriteAnimation>();
                    down = CreateAnimation(sprites, spriteActionName, actionInfo, "down");
                    actionNameWithDirection = actionInfo.name + "_down";
                    SaveAnimation(down, folderPath, spriteSheetName, actionNameWithDirection);

                    SO_SpriteAnimation left = ScriptableObject.CreateInstance<SO_SpriteAnimation>();
                    left = CreateAnimation(sprites, spriteActionName, actionInfo, "left");
                    actionNameWithDirection = actionInfo.name + "_left";
                    SaveAnimation(left, folderPath, spriteSheetName, actionNameWithDirection);

                    SO_SpriteAnimation right = ScriptableObject.CreateInstance<SO_SpriteAnimation>();
                    right = CreateAnimation(sprites, spriteActionName, actionInfo, "right");
                    actionNameWithDirection = actionInfo.name + "_right";
                    SaveAnimation(right, folderPath, spriteSheetName, actionNameWithDirection);
                }
            }
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }

    private static Texture2D ProcessTexture(Object obj) //returns Texture2D if is is a person spritesheet that has been processed
    {
        //skip if object isn't a Texture2D
        Texture2D texture = obj as Texture2D;
        if(texture == null) { return null; }

        //skip if texture isn't the right size
        if(texture.width != 256 || texture.height != 1568) { return null; }

        //get texture's importer
        TextureImporter importer = AssetImporter.GetAtPath(AssetDatabase.GetAssetPath(obj)) as TextureImporter;

        if (importer != null)
        {
            //modify import settings
            importer.isReadable = true;
            importer.spriteImportMode = SpriteImportMode.Multiple;
            importer.spritePixelsPerUnit = 16;
            importer.filterMode = FilterMode.Point;
            importer.textureCompression = TextureImporterCompression.Uncompressed;
            importer.SaveAndReimport();

            //clear existing sprite sheet settings
            importer.spritesheet = new SpriteMetaData[0];

            //sprite size
            int spriteWidth = 32;
            int spriteHeight = 32;

            //calculate number of sprites in rows and columns
            int numRows = texture.height / spriteHeight;
            int numCols = texture.width / spriteWidth;

            //create sprite meta data for each sprite
            List<SpriteMetaData> spriteMetaDataList = new List<SpriteMetaData>();
            int index = 0; //used to grab proper sprite name
            for (int y = numRows - 1; y >= 0; y--)
            {
                for (int x = 0; x < numCols; x++)
                {
                    //checking if location of sprite is empty
                    Rect rect = new Rect(x * spriteWidth, y * spriteHeight, spriteWidth, spriteHeight);
                    Color[] pixels = texture.GetPixels((int)rect.x, (int)rect.y, (int)rect.width, (int)rect.height);
                    bool isEmpty = true;
                    foreach (Color pixel in pixels)
                    {
                        if (pixel.a > 0.0f) // Assuming alpha > 0 means non-empty
                        {
                            isEmpty = false;
                            break;
                        }
                    }
                    if (!isEmpty) //creating metadata for sprite if location contains something
                    {
                        SpriteMetaData metaData = new SpriteMetaData();
                        metaData.rect = rect;
                        metaData.alignment = (int)SpriteAlignment.BottomCenter;
                        metaData.name = spriteNames[index];
                        index++;
                        spriteMetaDataList.Add(metaData);
                    }
                }
            }

            //set sprite sheet settings
            importer.spritesheet = spriteMetaDataList.ToArray();

            //apply changes
            //importer.isReadable = false;
            importer.SaveAndReimport();

            return texture;
        }
        else Debug.Log("Texture importer not found");
        return null;
    }
        
    private static SO_SpriteAnimation CreateAnimation(Sprite[] sprites, string spriteActionName, ActionAnimationInfo actionInfo, string direction = null) //returns null if sprites are missing
    {
        //creating animation
        SO_SpriteAnimation anim = ScriptableObject.CreateInstance<SO_SpriteAnimation>();
        anim.sprites = new Sprite[actionInfo.frames];

        for (int i = 0; i < actionInfo.frames; i++)
        {
            //generating name to find sprite by
            string spriteName;
            if (direction == null) //no direction
            {
                spriteName = spriteActionName + "_" + (i + 1);
            }
            else //direction
            {
                spriteName = spriteActionName + "_" + direction + "_" + (i + 1);
            }

            //finding sprite by name
            Sprite sprite = System.Array.Find(sprites, x => x.name == spriteName);
            if (sprite == null) { Debug.Log("Sprite missing: " + spriteName); return null; }

            //setting up animation
            anim.sprites[i] = sprite;
            anim.loops = actionInfo.loops;
            anim.secondsBetweenFrames = actionInfo.secondsBetweenFrames;
        }

        return anim;
    }

    private static void SaveAnimation(SO_SpriteAnimation anim, string folderPath, string spriteSheetName, string actionNameWithDirection)
    {
        if (anim != null)
        {
            //saving animation in folder
            string assetPath = Path.Combine(folderPath, spriteSheetName + "_" + actionNameWithDirection + ".asset");
            AssetDatabase.CreateAsset(anim, assetPath);
        }
    }

    private static Sprite[] ObjectArrayToSpriteArray(Object[] objectArray)
    {
        Sprite[] spriteArray = new Sprite[objectArray.Length];
        for (int i = 0; i < objectArray.Length; i++)
        {
            Sprite sprite = objectArray[i] as Sprite;
            spriteArray[i] = sprite;
        }
        return spriteArray;
    }
}

public class ActionAnimationInfo
{
    public string name;
    public int frames;
    public bool loops;
    public bool directional;
    public float secondsBetweenFrames;

    public ActionAnimationInfo(string name_, int frames_, bool loops_, bool directional_, float secondsBetweenFrames_)
    {
        name = name_;
        frames = frames_;
        loops = loops_;
        directional = directional_;
        secondsBetweenFrames = secondsBetweenFrames_;
    }
}