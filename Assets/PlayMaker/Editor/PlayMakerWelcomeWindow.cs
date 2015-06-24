// (c) Copyright HutongGames, LLC 2010-2011. All rights reserved.

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace HutongGames.PlayMakerEditor
{
    /// <summary>
    /// Welcome Window with getting started shortcuts
    /// </summary>
    public class PlayMakerWelcomeWindow : EditorWindow
    {
        private const string urlSamples = "http://www.hutonggames.com/samples.php";
        private const string urlTutorials = "http://www.hutonggames.com/tutorials.html";
        private const string urlDocs = "https://hutonggames.fogbugz.com/default.asp?W1";
        private const string urlForums = "http://hutonggames.com/playmakerforum/index.php";
        private const string urlPhotonAddon = "https://hutonggames.fogbugz.com/default.asp?W928";
        private const string urlAddonsWiki = "https://hutonggames.fogbugz.com/default.asp?W714";
        private const string urlEcosystemWiki = "https://hutonggames.fogbugz.com/default.asp?W1181";
        private const string urlStore = "http://www.hutonggames.com/store.html";
        private const string photonID = "1786";

        private const float windowWidth = 500;
        private const float windowHeight = 440;
        private const float pageTop = 70;
        private const float pagePadding = 95;

        private static bool setupPhoton;

        private enum Page
        {
            Welcome = 0,
            Install = 1,
            GettingStarted = 2,
            UpgradeGuide = 3,
            Addons = 4
        }
        private Page currentPage = Page.Welcome;
        private Page nextPage;
        private Rect currentPageRect;
        private Rect nextPageRect;
        private float currentPageMoveTo;

        private bool pageInTransition;
        private float transitionStartTime;
        private const float transitionDuration = 0.5f;

        private Vector2 scrollPosition;
        private bool showAtStartup;
        
        private static GUIStyle playMakerHeader;
        private static GUIStyle labelWithWordWrap;
        private static Texture samplesIcon;
        private static Texture docsIcon;
        private static Texture videosIcon;
        private static Texture forumsIcon;
        private static Texture addonsIcon;
        private static Texture photonIcon;

        private static bool stylesInitialized;

        [MenuItem("PlayMaker/Welcome Screen", false, 45)]
        public static void OpenWelcomeWindow()
        {
            GetWindow<PlayMakerWelcomeWindow>(true);
        }

        public void OnEnable()
        {
            title = "Welcome To PlayMaker";
            maxSize = new Vector2(windowWidth, windowHeight);
            minSize = maxSize;
 

            showAtStartup = EditorPrefs.GetBool("PlayMaker.WelcomeScreenAtStartup", true);
            setupPhoton = false; //ReflectionUtils.GetGlobalType("PlayMakerPhotonWizard") != null;

            currentPage = Page.Welcome;
            pageInTransition = false;
            currentPageRect = new Rect(0, pageTop, windowWidth, windowHeight-pagePadding);
            nextPageRect = new Rect(0, pageTop, windowWidth, windowHeight-pagePadding);
            Update();
        }

        private void InitStyles()
        {
            if (!stylesInitialized)
            {
                playMakerHeader = new GUIStyle
                {
                    normal =
                    {
                        background =
                            Resources.Load("playMakerHeader") as Texture2D,
                        textColor = Color.white
                    },
                    border = new RectOffset(253, 0, 0, 0),
                };
                labelWithWordWrap = new GUIStyle(EditorStyles.label) { wordWrap = true };
                samplesIcon = (Texture)Resources.Load("linkSamples");
                videosIcon = (Texture)Resources.Load("linkVideos");
                docsIcon = (Texture)Resources.Load("linkDocs");
                forumsIcon = (Texture)Resources.Load("linkForums");
                addonsIcon = (Texture)Resources.Load("linkAddons");
                photonIcon = (Texture)Resources.Load("photonIcon");
            }
            stylesInitialized = true;
        }

        public void OnGUI()
        {
            InitStyles();

            GUILayout.BeginVertical();
            GUI.Box(new Rect(0, 0, position.width, 60), "", playMakerHeader);
            GUILayoutUtility.GetRect(position.width, 60);

            GUILayout.BeginVertical();

            DoPage(currentPage, currentPageRect);
            if (pageInTransition)
            {
                DoPage(nextPage, nextPageRect);
            }

            // Bottom line

            GUILayout.FlexibleSpace();
            GUILayout.BeginHorizontal();

            // Back to Welcome page

            if (currentPage != Page.Welcome)
            {
                GUILayout.Space(10);
                if (GUILayout.Button("Back to Welcome Screen", EditorStyles.label))
                {
                    GotoPage(Page.Welcome);
                    GUIUtility.ExitGUI();
                    return;
                }
                EditorGUIUtility.AddCursorRect(GUILayoutUtility.GetLastRect(), MouseCursor.Link);
            }

            GUILayout.FlexibleSpace();

            // Show at startup?

            var show = GUILayout.Toggle(showAtStartup, "Show At Startup");
            if (show != showAtStartup)
            {
                showAtStartup = show;
                EditorPrefs.SetBool("PlayMaker.WelcomeAtStartup", showAtStartup);
            }

            GUILayout.Space(10);
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.EndVertical();
        }

        private void DoPage(Page page, Rect pageRect)
        {
            pageRect.height = position.height - pagePadding;
            GUILayout.BeginArea(pageRect);

            switch (page)
            {
                case Page.Welcome:
                    DoWelcomePage();
                    break;
                case Page.Install:
                    DoInstallPage();
                    break;
                case Page.GettingStarted:
                    DoGettingStartedPage();
                    break;
                case Page.UpgradeGuide:
                    DoUpgradeGuidePage();
                    break;
                case Page.Addons:
                    DoAddonsPage();
                    break;
            }

            GUILayout.EndArea();
        }

        private void DoWelcomePage()
        {
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            DrawLink(samplesIcon,
                     "Install PlayMaker",
                     "Import the latest version of PlayMaker.",
                     GotoPage, Page.Install);

            DrawLink(docsIcon,
                     "Upgrade Guide",
                     "Guide to upgrading Unity/PlayMaker.",
                     GotoPage, Page.UpgradeGuide);

            DrawLink(videosIcon,
                     "Getting Started",
                     "Links to samples, tutorials, forums etc.",
                     GotoPage, Page.GettingStarted);

            DrawLink(addonsIcon,
                 "Add-Ons",
                 "Extend PlayMaker with these powerful add-ons.",
                 GotoPage, Page.Addons);

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        private void DoInstallPage()
        {
            ShowBackupHelpBox();

            GUILayout.BeginVertical();
            GUILayout.Space(30);

            DrawLink(samplesIcon,
                     "Install PlayMaker 1.7.8.3",
                     "The latest stable release.",
                     GotoPage, Page.UpgradeGuide);

            DrawLink(samplesIcon,
                     "Install PlayMaker 1.8.0 (Beta)",
                     "A public beta for 1.8.0.",
                     GotoPage, Page.UpgradeGuide);

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        private void DoGettingStartedPage()
        {
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            DrawLink(samplesIcon,
                 "Samples",
                 "Download sample scenes and complete projects.",
                 OpenUrl, urlSamples);

            DrawLink(videosIcon,
                 "Tutorials",
                 "Watch tutorials on the PlayMaker YouTube channel.",
                 OpenUrl, urlTutorials);

            DrawLink(docsIcon,
                 "Docs",
                 "Browse the online manual.",
                 OpenUrl, urlDocs);

            DrawLink(forumsIcon,
                 "Forums",
                 "Join the PlayMaker community!",
                 OpenUrl, urlForums);

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        private void DoUpgradeGuidePage()
        {
            ShowBackupHelpBox();

            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

            GUILayout.Label("Version 1.8.0", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("FSMs saved with 1.8.0 cannot be opened in earlier versions of PlayMaker! Please BACKUP projects!", MessageType.Warning);

            GUILayout.Label("Unity 5 Upgrade Notes", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("If you run into problems updating a Unity 4.x project please check the Troubleshooting guide on the PlayMaker Wiki.", MessageType.Warning);
            EditorGUILayout.HelpBox("Unity 5 removed component property shortcuts from GameObject. " +
                                    "\n\nThe Unity auto update process replaces these properties with GetComponent calls. " +
                                    "In many cases this is fine, but some third party actions and addons might need manual updating! " +
                                    "Please post on the PlayMaker forums and contact the original authors for help." +
                                    "\n\nIf you used these GameObject properties in Get Property or Set Property actions " +
                                    "they are no longer valid, and you need to instead point to the Component directly. " +
                                    "E.g., Drag the Component (NOT the GameObject) into the Target Object field." +
                                    "\n", MessageType.Warning);

            GUILayout.Label("Unity 4.6 Upgrade Notes", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("Find support for the new Unity GUI online in our Addons page.", MessageType.Info);
            EditorGUILayout.HelpBox("PlayMakerGUI is only needed if you use OnGUI Actions. " +
                                    "If you don't use OnGUI actions un-check Auto-Add PlayMakerGUI in PlayMaker Preferences.", MessageType.Info);

            EditorGUILayout.EndScrollView();
            //FsmEditorGUILayout.Divider();
        }

        private void DoAddonsPage()
        {
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            if (setupPhoton)
            {
                DrawLink(photonIcon,
                     "Photon",
                     "Photon...",
                     LaunchPhotonSetupWizard, null);
            }
            else
            {
                DrawLink(photonIcon,
                     "Photon",
                     "Photon...",
                     OpenUrl, urlPhotonAddon);
            }

            DrawLink(addonsIcon,
                 "Ecosystem",
                 "An integrated online browser for custom actions, samples and addons.",
                 OpenUrl, urlEcosystemWiki);

            DrawLink(addonsIcon,
                 "Add-Ons",
                 "Find action packs and add-ons for NGUI, 2D Toolkit, Mecanim, Pathfinding, Smooth Moves, Ultimate FPS...",
                 OpenUrl, urlAddonsWiki);

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();

        }

        private static void ShowBackupHelpBox()
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("Always BACKUP projects before updating!\nUse Version Control to manage changes!", MessageType.Error);
            GUILayout.Space(5);
            GUILayout.EndHorizontal();
        }

        private static void DrawLink(Texture texture, string heading, string body, LinkFunction func, object userData)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Space(64);
            GUILayout.Box(texture, GUIStyle.none, GUILayout.MaxWidth(48));
            GUILayout.Space(10);

            GUILayout.BeginVertical();
            GUILayout.Space(1);
            GUILayout.Label(heading, EditorStyles.boldLabel);
            GUILayout.Label(body, labelWithWordWrap);
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();

            var rect = GUILayoutUtility.GetLastRect();
            EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);

            if (Event.current.type == EventType.mouseDown && rect.Contains(Event.current.mousePosition))
            {
                func(userData);
            }

            GUILayout.Space(10);
        }

        void Update()
        {
            if (pageInTransition)
            {
                DoPageTransition();
            }
        }

        void DoPageTransition()
        {
            var t = (Time.realtimeSinceStartup - transitionStartTime) / transitionDuration;
            if (t > 1f)
            {
                pageInTransition = false;
                currentPage = nextPage;
                currentPageRect.x = 0;
                Repaint();
                return;
            }

            var nextPageX = Mathf.SmoothStep(nextPageRect.x, 0, t);
            var currentPageX = Mathf.SmoothStep(currentPageRect.x, currentPageMoveTo, t);
            currentPageRect.Set(currentPageX, pageTop, windowWidth, position.height);
            nextPageRect.Set(nextPageX, pageTop, windowWidth, position.height);

            Repaint();
        }

        // Button actions:

        public delegate void LinkFunction(object userData);

        private void LaunchPhotonSetupWizard(object userData)
        {
            //ReflectionUtils.GetGlobalType("PlayMakerPhotonWizard").GetMethod("Init").Invoke(null, null);
        }

        private void OpenUrl(object userData)
        {
            Application.OpenURL(userData as string);
        }

        private void OpenInAssetStore(object userData)
        {
            AssetStore.Open("content/" + userData);
        }

        private void GotoPage(object userData)
        {
            nextPage = (Page)userData;
            pageInTransition = true;
            transitionStartTime = Time.realtimeSinceStartup;

            // next page slides in from the right
            // welcome screen slides offscreen left
            // reversed if returning to the welcome screen

            if (nextPage == Page.Welcome)
            {
                nextPageRect.x = -windowWidth;
                currentPageMoveTo = windowWidth;
            }
            else
            {
                nextPageRect.x = windowWidth;
                currentPageMoveTo = -windowWidth;
            }

            GUIUtility.ExitGUI();
        }
    }
}