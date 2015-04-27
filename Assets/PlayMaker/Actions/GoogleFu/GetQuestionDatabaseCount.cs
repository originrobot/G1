using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("GoogleFu")]
	[Tooltip("Gets the specified entry in the QuestionDatabase Database By Index.")]
	public class GetQuestionDatabaseCount : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The object that contains the QuestionDatabase database.")]
		public FsmGameObject databaseObj;
		[UIHint(UIHint.Variable)]
		[Tooltip("Row Count of the database.")]
		public FsmInt rowCount;
		public override void Reset()
		{
			databaseObj = null;
			rowCount = null;
		}
		public override void OnEnter()
		{
			if ( databaseObj != null && rowCount != null )
			{
				GoogleFu.QuestionDatabase db = databaseObj.Value.GetComponent<GoogleFu.QuestionDatabase>();
				rowCount.Value = db.Rows.Count;
			}
			Finish();
		}
	}
}
