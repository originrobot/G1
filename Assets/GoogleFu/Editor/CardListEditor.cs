using UnityEngine;
using UnityEditor;

namespace GoogleFu
{
	[CustomEditor(typeof(CardList))]
	public class CardListEditor : Editor
	{
		public int Index = 0;
		public override void OnInspectorGUI ()
		{
			CardList s = target as CardList;
			CardListRow r = s.Rows[ Index ];

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
			GUILayout.Label( "CARD", GUILayout.Width( 150.0f ) );
			{
				EditorGUILayout.TextField( r._CARD );
			}
			EditorGUILayout.EndHorizontal();

		}
	}
}
