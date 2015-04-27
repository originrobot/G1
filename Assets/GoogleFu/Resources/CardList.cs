//----------------------------------------------
//    GoogleFu: Google Doc Unity integration
//         Copyright ?? 2013 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;

namespace GoogleFu
{
	[System.Serializable]
	public class CardListRow 
	{
		public string _CARD;
		public CardListRow(string __CARD) 
		{
			_CARD = __CARD;
		}

		public int Length { get { return 1; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _CARD.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			string ret = System.String.Empty;
			switch( colID.ToUpper() )
			{
				case "CARD":
					ret = _CARD.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "CARD" + " : " + _CARD.ToString() + "} ";
			return ret;
		}
	}
	public class CardList :  GoogleFuComponentBase
	{
		public enum rowIds {
			card1, card2, card3, card4, card5, card6, card7, card8, card9, card10, card11, card12, card13, card14, card15, card16, card17, card18, card19, card20, 
			card21, card22, card23, card24, card25
		};
		public string [] rowNames = {
			"card1", "card2", "card3", "card4", "card5", "card6", "card7", "card8", "card9", "card10", "card11", "card12", "card13", "card14", "card15", "card16", "card17", "card18", "card19", "card20", 
			"card21", "card22", "card23", "card24", "card25"
		};
		public System.Collections.Generic.List<CardListRow> Rows = new System.Collections.Generic.List<CardListRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new CardListRow(input[0]));
		}
		public override void Clear ()
		{
			Rows.Clear();
		}
		public CardListRow GetRow(rowIds rowID)
		{
			CardListRow ret = null;
			try
			{
				ret = Rows[(int)rowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( rowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public CardListRow GetRow(string rowString)
		{
			CardListRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), rowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( rowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
