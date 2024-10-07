This tutorial is from the book Hands-on Unity 2021 game development : create, customize, and optimize your own professional games from scratch with Unity 2021 / Nicolas Alejandro Borromeo. <br/>

In SuperShooting, we need 2D Sprite to edit UI images, changing the image resize parts in a 9*9 area. <br/>
We also need Cinemachine to add virtual camera, Cinemachine smoothpart to control the camera track, then use Director object to change the main camera to be displayed. Director use animation instead of animator window. <br/>
We need Volume component(PPVolume) to add post processing special effects. <br/>
We can use Terrain component or ProBuilder to draw terrain. <br/>
We can use Shader Graph to make material and texture, such as water surface. <br/>
We can use particle system or Visual Effect Graph(VFX) to make our particle animation, such as fire, smoke, rain fall and water fall. Please refer to the game for particle system to see what can be changed because many options can be changed. <br/>
We can use Canvas system to make UI with TextMeshPro or UIBuilder to make UI, UIToolkit(UIBuilder) is a relatively new system, so it maybe not stable. If using Canvas, we must use EventSystem to make the buttons to be clickable. UIBuilder will use USS stylesheet, such as CSS stylesheet as template. We can set the Canvas reference resolution to match the art resolution on the creator computer. We can use the 4 piece from the cross to change the relative position of object to screen. <br/>
We can use light probe groups to bake lightmaps, Windows->Rendering->Lighting will have the baked lightmaps options. Remember to set static in up right in inspector to let renderer baking the object. <br/>
We can use audio mixer controller to mix background music and sound effects. In audio, we can change the sound to be 2D or 3D(decrease based on distance), and the decrease line, which can be linear or exponential decrease(realistic). Audio can be changed as decompressed on load, compressed on memory or streaming, the front will use more ram resources and the latter will use more CPU resources. So the front is good for small and short but frequent sound, background music should use streaming. We should use ADPCM for compression format, Vorbis for lossy compression, don't use PCM because it used most of the space, unless we required perfect sound, like background music. If the quality doesn't matter, such as rain noise, we should use ADPCM. <br/>
We can level of detail(LOD) to change the visibility of object at different distance.
We can use Visual Scripting to add script instead of writing script. But only use either Visual Scripting or C# script because both will be activated. <br/>
We can add manager in scripting to watch for mono object, such as wave, score, which won't exist more than 1. Then use AddListener in Awake to register event. <br/>
Awake will call when script initialize, no matter enabled or not. Then OnStart will be called after awake, then update. Enable can disable update events but not On(x) events, because they are registered events. We use static keyword to initialize static object. We can use GetComponent to get self, child or parent components, but not neighbour object with same relationship. <br/>
We can use State Graph to make a state change FSM. <br/>
Script graph has graph, object, scene, app and saved variable, graph is local in the graph only, object is within object, scene is within 1 scene, saved for saving data. <br/>
We can add #if !(UNITY_EDITOR || DEVELOPMENT_BUILD) print("..."); #endif for debugging, this will executed in the compiler to check whether is editor version or build version. <br/>
We can use Profiler to check the CPU/GPU/RAM usage in game. Click on the profiler will stop the game, deep profile can check function calls, but use more time. We can also use Frame Debugger to see how 1 frame is generated. Changing URP to fixed pipeline will be slower because batching isn't used, the same material on different object can be batched. But if the object have too many vertexes, such as circle, it won't batched together. <br/>
We can also use Memory Profiler to capture the memory usage at 1 moment, and check the tree map to see what used the most memory. If texture2D used too much spaces, we can change the max size of the texture.<br/>
Rigidbody isKinemetic is for scripting objects. Using this won't affect by other collider or force. <br/>
Windows-> Rendering->Occulusion culling can bake occulusion, we can change the smallest occluder become smaller, which will detect better, but the baked resources will use more spaces on ram.<br/>



AR: <br/>
In AR part, we need ARCore for android or ARKit for mac. Then we need ARFoundation and XRPluginManagement. <br/>
We need a AR Session Orign with managers to control other objects rendering. <br/>
Put the tracking image into reference image library, then instantiate AR Tracked Image Manager to track player. <br/>
Then we use AR Plane Manager to track plane, and AR Raycast Manager to track the position we touch on screen. <br/>
We need to enable USB debugging mode in phone, connect to PC and change the build to android version. Then hit build and run, it will install and run in android automatically. <br/>
We can install logcat in Unity for debug. <br/>
We need to install google AR, some devices support it, usually is the newer and powerful device. Check the device list here: https://developers.google.com/ar/devices?hl=zh-tw <br/>
