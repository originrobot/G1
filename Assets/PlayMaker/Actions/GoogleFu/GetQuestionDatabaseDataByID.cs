using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("GoogleFu")]
	[Tooltip("Gets the specified entry in the QuestionDatabase Database.")]
	public class GetQuestionDatabaseDataByID : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The object that contains the QuestionDatabase database.")]
		public FsmGameObject databaseObj;
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Row name of the entry you wish to retrieve.")]
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
			rowName = null;
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
			if ( databaseObj != null && rowName != null && rowName.Value != System.String.Empty )
			{
				GoogleFu.QuestionDatabase db = databaseObj.Value.GetComponent<GoogleFu.QuestionDatabase>();
				GoogleFu.QuestionDatabaseRow row = db.GetRow( rowName.Value );
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
