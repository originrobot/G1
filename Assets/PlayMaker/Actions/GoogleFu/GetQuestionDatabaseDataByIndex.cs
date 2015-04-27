using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("GoogleFu")]
	[Tooltip("Gets the specified entry in the QuestionDatabase Database By Index.")]
	public class GetQuestionDatabaseDataByIndex : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The object that contains the QuestionDatabase database.")]
		public FsmGameObject databaseObj;
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Row index of the entry you wish to retrieve.")]
		public FsmInt rowIndex;
		[UIHint(UIHint.Variable)]
		[Tooltip("Row ID of the entry.")]
		public FsmString rowName;
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the _QUESTION in a string variable.")]
		public FsmString _QUESTION;
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the _ANSWER in a string variable.")]
		public FsmString _ANSWER;
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the _ANSWERWRONG1 in a string variable.")]
		public FsmString _ANSWERWRONG1;
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the _ANSWERWRONG2 in a string variable.")]
		public FsmString _ANSWERWRONG2;
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the _ANSWERWRONG3 in a string variable.")]
		public FsmString _ANSWERWRONG3;
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the _CATEGORY in a string variable.")]
		public FsmString _CATEGORY;
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the _DIFFICULTY in a int variable.")]
		public FsmInt _DIFFICULTY;
		public override void Reset()
		{
			databaseObj = null;
			rowIndex = null;
			_QUESTION = null;
			_ANSWER = null;
			_ANSWERWRONG1 = null;
			_ANSWERWRONG2 = null;
			_ANSWERWRONG3 = null;
			_CATEGORY = null;
			_DIFFICULTY = null;
		}
		public override void OnEnter()
		{
			if ( databaseObj != null && rowIndex != null )
			{
				GoogleFu.QuestionDatabase db = databaseObj.Value.GetComponent<GoogleFu.QuestionDatabase>();
				// For sanity sake, we are going to do an auto-wrap based on the input
				// This should prevent accessing the array out of bounds
				int i = rowIndex.Value;
				int L = db.Rows.Count;
				while ( i < 0 )
					i += L;
				while ( i > L-1 )
					i -= L;
				GoogleFu.QuestionDatabaseRow row = db.Rows[i];
				if ( rowName != null && rowName.Value == string.Empty )
					rowName.Value = db.rowNames[i];
				if ( _QUESTION != null )
				_QUESTION.Value = row._QUESTION;
				if ( _ANSWER != null )
				_ANSWER.Value = row._ANSWER;
				if ( _ANSWERWRONG1 != null )
				_ANSWERWRONG1.Value = row._ANSWERWRONG1;
				if ( _ANSWERWRONG2 != null )
				_ANSWERWRONG2.Value = row._ANSWERWRONG2;
				if ( _ANSWERWRONG3 != null )
				_ANSWERWRONG3.Value = row._ANSWERWRONG3;
				if ( _CATEGORY != null )
				_CATEGORY.Value = row._CATEGORY;
				if ( _DIFFICULTY != null )
				_DIFFICULTY.Value = row._DIFFICULTY;
			}
			Finish();
		}
	}
}
