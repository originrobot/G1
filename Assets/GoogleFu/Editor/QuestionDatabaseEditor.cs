using UnityEngine;
using UnityEditor;

namespace GoogleFu
{
	[CustomEditor(typeof(QuestionDatabase))]
	public class QuestionDatabaseEditor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			QuestionDatabase s = target as QuestionDatabase;
			QuestionDatabaseRow r = s.Rows[ Index ];

			EditorGUILayout.BeginHorizontal();
			if ( GUILayout.Button("<<") )
			{
				Index = 0;
			}
			if ( GUILayout.Button("<") )
			{
				Index -= 1;
				if ( Index < 0 )
					Index = s.Rows.Count - 1;
			}
			if ( GUILayout.Button(">") )
			{
				Index += 1;
				if ( Index >= s.Rows.Count )
					Index = 0;
			}
			if ( GUILayout.Button(">>") )
			{
				Index = s.Rows.Count - 1;
			}

			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ID", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.LabelField( s.rowNames[ Index ] );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "QUESTION", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._QUESTION );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ANSWER", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._ANSWER );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ANSWERWRONG1", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._ANSWERWRONG1 );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ANSWERWRONG2", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._ANSWERWRONG2 );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "ANSWERWRONG3", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._ANSWERWRONG3 );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "CATEGORY", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._CATEGORY );
			}
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
			GUILayout.Label( "DIFFICULTY", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.IntField( r._DIFFICULTY );
			}
			EditorGUILayout.EndHorizontal();

		}
	}
}
