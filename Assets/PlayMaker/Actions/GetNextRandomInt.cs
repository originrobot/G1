// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GameObject)]
	[Tooltip("Each time this action is called it gets a random int from a pool, which means always unique results, you will end up with no duplicated ints.\n" +
	 	"so if you want a series within a range of 5, you might get first 3, the next iteration will pick a random number in 1 2 4 5, because 3 is out already.")]
	public class GetNextRandomInt : FsmStateAction
	{
		
		[RequiredField]
		[Tooltip("Defines the int pool range to pick from at random. Starts at 1")]
		public FsmInt intPoolCount;
		
		public FsmInt intSerieCount;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the next int from the series.")]
		public FsmInt storeNextInt;

		[Tooltip("Event to send to get the next child.")]
		public FsmEvent loopEvent;

		[Tooltip("Event to send when there are no more children.")]
		public FsmEvent finishedEvent;

		public override void Reset()
		{
			intPoolCount = 10;
			storeNextInt = null;
			loopEvent = null;
			finishedEvent = null;
		}

		// cache the gameObject so we no if it changes
		private GameObject go;

		// increment the next pick to pick from the pool
		private int _nextPick;
		
		
		private ArrayList intPool;
		
		public override void OnEnter()
		{

			DoGetNextPick();

			Finish();
		}
		
		void start()
		{
			intPool = new ArrayList();
			for (int i = 1;i<=intPoolCount.Value;i++)
			{
				intPool.Add(i);
			}

			_nextPick = 0;
		}

		void DoGetNextPick()
		{
			if (intPool==null)
			{
				start ();
			}
			
			if ( _nextPick >= intPoolCount.Value || _nextPick >= intSerieCount.Value)
			{
				start();
				Fsm.Event(finishedEvent);
				return;
			}

			// get next pick
			int randomIndex = Random.Range(0,intPool.Count);
			storeNextInt.Value = (int)intPool[randomIndex];
			intPool.RemoveAt(randomIndex);
			
			Debug.Log(storeNextInt.Value);

			// no more pick?
			// check a second time to avoid process lock and possible infinite loop if the action is called again.
			// Practically, this enabled calling again this state and it will start again iterating from the first pick.

			if (_nextPick >= intPoolCount.Value)
			{
				start();
				Fsm.Event(finishedEvent);
				return;
			}

			// iterate the next pick
			_nextPick++;

			if (loopEvent != null)
			{
				Fsm.Event(loopEvent);
			}
		}
	}
}