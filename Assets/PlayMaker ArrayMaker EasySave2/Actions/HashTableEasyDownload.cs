//	(c) Jean Fabre, 2011-2015 All rights reserved.
//	http://www.fabrejean.net

// INSTRUCTIONS
// Drop a PlayMakerHashTableProxy script onto a GameObject, and define a unique name for reference if several PlayMakerHashTableProxy coexists on that GameObject.
// In this Action interface, link that GameObject in "hashTableObject" and input the reference name if defined. 
// Note: You can directly reference that GameObject or store it in an Fsm variable or global Fsm variable

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Easy Save 2")]
	[Tooltip("Loads a PlayMaker HashTable Proxy component From MySQL Server via ES2.php file. See moodkie.com/easysave/WebSetup.php for how to set up MySQL.")]
	public class HashTableEasyDownload : HashTableActions
	{
		
		[ActionSection("Set up")]
		
		[RequiredField]
		[Tooltip("The gameObject with the PlayMaker HashTable Proxy component")]
		[CheckForComponent(typeof(PlayMakerHashTableProxy))]
		public FsmOwnerDefault gameObject;

		[Tooltip("Author defined Reference of the PlayMaker HashTable Proxy component ( necessary if several component coexists on the same GameObject")]
		[UIHint(UIHint.FsmString)]
		public FsmString reference;
		
		[Tooltip("A unique tag for this save. For example, the object's name if no other objects use the same name. Leave to none or empty, to use the GameObject Name + Fsm Name + hashtable Reference as tag.")]
		public FsmString uniqueTag = "";
		
		[RequiredField]
		[Tooltip("The name of the file that we'll create to store our data. Leave as default if unsure.")]
		public FsmString saveFile = "defaultES2File.txt";
		
		[Tooltip("The name of the local file we want to create to store our data. Leave blank if you don't want to store data locally.")]
		public FsmString localFile = "";
		
		
		[ActionSection("Upload Set up")]
		
		[RequiredField]
		[Tooltip("The URL to our ES2.PHP file. See http://www.moodkie.com/easysave/WebSetup.php for more information on setting up ES2Web")]
		public FsmString urlToPHPFile = "http://www.mysite.com/ES2.php";
		[RequiredField]
		[Tooltip("The username that you have specified in your ES2.php file.")]
		public FsmString username = "ES2";
		[RequiredField]
		[Tooltip("The password that you have specified in your ES2.php file.")]
		public FsmString password = "65w84e4p994z3Oq";
		
		
		[ActionSection("Result")]
		[Tooltip("The Event to send if Download succeeded.")]
		public FsmEvent isDownloaded;
		[Tooltip("The event to send if Download failed.")]
		public FsmEvent isError;
		[Tooltip("Where any errors thrown will be stored. Set this to a variable, or leave it blank.")]
		public FsmString errorMessage = "";
		[Tooltip("Where any error codes thrown will be stored. Set this to a variable, or leave it blank.")]
		public FsmString errorCode = "";
		
		private ES2Web web = null;
		
		private string _tag;
		
		public override void Reset()
		{
			gameObject = null;
			reference = null;
			
			uniqueTag = new FsmString(){UseVariable=true};
			localFile = "";
			saveFile = "defaultES2File.txt";
			urlToPHPFile = "http://www.mysite.com/ES2.php";
			web = null;
			errorMessage = "";
			errorCode = "";
		}
		
			
		
		public override void OnEnter()
		{
			if ( SetUpHashTableProxyPointer(Fsm.GetOwnerDefaultTarget(gameObject),reference.Value) )
			{
				DownloadHashTable();
			}
		}
		
		private void DownloadHashTable()
		{
			if (! isProxyValid() ) 
				return;
			
			
			_tag = uniqueTag.Value;
			if (string.IsNullOrEmpty(_tag))
			{
				_tag = Fsm.GameObjectName+"/"+Fsm.Name+"/hashTable/"+reference.Value;
			}
			
			
			
			web = new ES2Web(urlToPHPFile+"?tag="+_tag+"&webfilename="+saveFile.Value+"&webpassword="+password.Value+"&webusername="+username.Value);
			this.Fsm.Owner.StartCoroutine(web.Download());
			Log("Downloading from "+urlToPHPFile.Value+"?tag="+uniqueTag.Value+"&webfilename="+saveFile.Value);
		}
		
		public override void OnUpdate()
		{
			if(web.isError)
			{
				errorMessage.Value = web.error;
				errorCode.Value = web.errorCode;
				Fsm.Event(isError);
				Finish();
			}
			else if(web.isDone)
			{
				Fsm.Event(isDownloaded);
				
				Dictionary<string,string> _dict = web.LoadDictionary<string,string>(_tag);
			
				if(localFile.Value != "")
				{
					web.SaveToFile(localFile.Value);
				}
				
				Log("DownLoaded from "+saveFile.Value+"?tag="+_tag);
	
				proxy.hashTable.Clear();
				
				foreach(string key in _dict.Keys)
				{		
					proxy.hashTable[key] = PlayMakerUtils.ParseValueFromString(_dict[key]);
				}
				
				Finish();
			}
		}
		
	}
}