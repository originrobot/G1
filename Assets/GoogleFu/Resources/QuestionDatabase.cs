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
	public class QuestionDatabaseRow 
	{
		public string _QUESTION;
		public string _ANSWER;
		public string _ANSWERWRONG1;
		public string _ANSWERWRONG2;
		public string _ANSWERWRONG3;
		public string _CATEGORY;
		public int _DIFFICULTY;
		public QuestionDatabaseRow(string __QUESTION, string __ANSWER, string __ANSWERWRONG1, string __ANSWERWRONG2, string __ANSWERWRONG3, string __CATEGORY, string __DIFFICULTY) 
		{
			_QUESTION = __QUESTION;
			_ANSWER = __ANSWER;
			_ANSWERWRONG1 = __ANSWERWRONG1;
			_ANSWERWRONG2 = __ANSWERWRONG2;
			_ANSWERWRONG3 = __ANSWERWRONG3;
			_CATEGORY = __CATEGORY;
			{
			int res;
				if(int.TryParse(__DIFFICULTY, out res))
					_DIFFICULTY = res;
				else
					Debug.LogError("Failed To Convert DIFFICULTY string: "+ __DIFFICULTY +" to int");
			}
		}

		public int Length { get { return 7; } }

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
					ret = _QUESTION.ToString();
					break;
				case 1:
					ret = _ANSWER.ToString();
					break;
				case 2:
					ret = _ANSWERWRONG1.ToString();
					break;
				case 3:
					ret = _ANSWERWRONG2.ToString();
					break;
				case 4:
					ret = _ANSWERWRONG3.ToString();
					break;
				case 5:
					ret = _CATEGORY.ToString();
					break;
				case 6:
					ret = _DIFFICULTY.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			string ret = System.String.Empty;
			switch( colID.ToUpper() )
			{
				case "QUESTION":
					ret = _QUESTION.ToString();
					break;
				case "ANSWER":
					ret = _ANSWER.ToString();
					break;
				case "ANSWERWRONG1":
					ret = _ANSWERWRONG1.ToString();
					break;
				case "ANSWERWRONG2":
					ret = _ANSWERWRONG2.ToString();
					break;
				case "ANSWERWRONG3":
					ret = _ANSWERWRONG3.ToString();
					break;
				case "CATEGORY":
					ret = _CATEGORY.ToString();
					break;
				case "DIFFICULTY":
					ret = _DIFFICULTY.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "QUESTION" + " : " + _QUESTION.ToString() + "} ";
			ret += "{" + "ANSWER" + " : " + _ANSWER.ToString() + "} ";
			ret += "{" + "ANSWERWRONG1" + " : " + _ANSWERWRONG1.ToString() + "} ";
			ret += "{" + "ANSWERWRONG2" + " : " + _ANSWERWRONG2.ToString() + "} ";
			ret += "{" + "ANSWERWRONG3" + " : " + _ANSWERWRONG3.ToString() + "} ";
			ret += "{" + "CATEGORY" + " : " + _CATEGORY.ToString() + "} ";
			ret += "{" + "DIFFICULTY" + " : " + _DIFFICULTY.ToString() + "} ";
			return ret;
		}
	}
	public class QuestionDatabase :  GoogleFuComponentBase
	{
		public enum rowIds {
			Question1, Question2, Question3, Question4, Question5, Question6, Question7, Question8, Question9, Question10, Question11, Question12, Question13, Question14, Question15, Question16, Question17, Question18, Question19, Question20, 
			Question21, Question22, Question23, Question24, Question25, Question26, Question27, Question28, Question29, Question30, Question31, Question32, Question33, Question34, Question35, Question36, Question37, Question38, Question39, Question40, 
			Question41, Question42, Question43, Question44, Question45, Question46, Question47, Question48, Question49, Question50, Question51, Question52, Question53, Question54, Question55, Question56, Question57, Question58, Question59, Question60, 
			Question61, Question62, Question63, Question64, Question65, Question66, Question67, Question68, Question69, Question70, Question71, Question72, Question73, Question74, Question75, Question76, Question77, Question78, Question79, Question80, 
			Question81, Question82, Question83, Question84, Question85, Question86, Question87, Question88, Question89, Question90, Question91, Question92, Question93, Question94, Question95, Question96, Question97, Question98, Question99, Question100, 
			Question101, Question102, Question103, Question104, Question105, Question106, Question107, Question108, Question109, Question110, Question111, Question112, Question113, Question114, Question115, Question116, Question117, Question118, Question119, Question120, 
			Question121, Question122, Question123, Question124, Question125, Question126, Question127, Question128, Question129, Question130, Question131, Question132, Question133, Question134, Question135, Question136, Question137, Question138, Question139, Question140, 
			Question141, Question142, Question143, Question144, Question145, Question146, Question147, Question148, Question149, Question150, Question151, Question152, Question153, Question154, Question155, Question156, Question157, Question158, Question159, Question160, 
			Question161, Question162, Question163, Question164, Question165, Question166, Question167, Question168, Question169, Question170, Question171, Question172, Question173, Question174, Question175, Question176, Question177, Question178, Question179, Question180, 
			Question181, Question182, Question183, Question184, Question185, Question186, Question187, Question188, Question189, Question190, Question191, Question192, Question193, Question194, Question195, Question196, Question197, Question198, Question199, Question200, 
			Question201, Question202, Question203, Question204, Question205, Question206, Question207, Question208, Question209, Question210, Question211, Question212, Question213, Question214, Question215, Question216, Question217, Question218, Question219, Question220, 
			Question221, Question222, Question223, Question224, Question225, Question226, Question227, Question228, Question229, Question230, Question231, Question232, Question233, Question234, Question235, Question236, Question237, Question238, Question239, Question240, 
			Question241, Question242, Question243, Question244, Question245, Question246, Question247, Question248, Question249, Question250, Question251, Question252, Question253, Question254, Question255, Question256, Question257, Question258, Question259, Question260, 
			Question261, Question262, Question263, Question264, Question265, Question266, Question267, Question268, Question269, Question270, Question271, Question272, Question273, Question274, Question275, Question276, Question277, Question278, Question279, Question280, 
			Question281, Question282, Question283, Question284, Question285, Question286, Question287, Question288, Question289, Question290, Question291, Question292, Question293, Question294, Question295, Question296, Question297, Question298, Question299, Question300, 
			Question301, Question302, Question303, Question304, Question305, Question306, Question307, Question308, Question309, Question310, Question311, Question312, Question313, Question314, Question315, Question316, Question317, Question318, Question319, Question320, 
			Question321, Question322, Question323, Question324, Question325, Question326, Question327, Question328, Question329, Question330, Question331, Question332, Question333, Question334, Question335, Question336, Question337, Question338, Question339, Question340, 
			Question341, Question342, Question343, Question344, Question345, Question346, Question347, Question348, Question349, Question350, Question351, Question352, Question353, Question354, Question355, Question356, Question357, Question358, Question359, Question360, 
			Question361, Question362, Question363, Question364, Question365, Question366, Question367, Question368, Question369, Question370, Question371, Question372, Question373, Question374, Question375, Question376, Question377, Question378, Question379, Question380, 
			Question381, Question382, Question383, Question384, Question385, Question386, Question387, Question388, Question389, Question390, Question391, Question392, Question393, Question394, Question395, Question396, Question397, Question398, Question399, Question400, 
			Question401, Question402, Question403, Question404, Question405, Question406, Question407, Question408, Question409, Question410, Question411, Question412, Question413, Question414, Question415, Question416, Question417, Question418, Question419, Question420, 
			Question421, Question422, Question423, Question424, Question425, Question426, Question427, Question428, Question429, Question430, Question431, Question432, Question433, Question434, Question435, Question436, Question437, Question438, Question439, Question440, 
			Question441, Question442, Question443, Question444, Question445, Question446, Question447, Question448, Question449, Question450, Question451, Question452, Question453, Question454, Question455, Question456, Question457, Question458, Question459, Question460, 
			Question461, Question462, Question463, Question464, Question465, Question466, Question467, Question468, Question469, Question470, Question471, Question472, Question473, Question474, Question475, Question476, Question477, Question478, Question479, Question480, 
			Question481, Question482, Question483, Question484, Question485, Question486, Question487, Question488, Question489, Question490, Question491, Question492, Question493, Question494, Question495, Question496, Question497, Question498, Question499, Question500, 
			Question501, Question502, Question503, Question504, Question505, Question506, Question507, Question508, Question509, Question510, Question511, Question512, Question513, Question514, Question515, Question516, Question517, Question518, Question519, Question520, 
			Question521, Question522, Question523, Question524, Question525, Question526, Question527, Question528, Question529, Question530, Question531, Question532, Question533, Question534, Question535, Question536, Question537, Question538, Question539, Question540, 
			Question541, Question542, Question543, Question544, Question545, Question546, Question547, Question548, Question549, Question550, Question551, Question552, Question553, Question554, Question555, Question556, Question557, Question558, Question559, Question560, 
			Question561, Question562, Question563, Question564, Question565, Question566, Question567, Question568, Question569, Question570, Question571, Question572, Question573, Question574, Question575, Question576, Question577, Question578, Question579, Question580, 
			Question581, Question582, Question583, Question584, Question585, Question586, Question587, Question588, Question589, Question590, Question591, Question592, Question593, Question594, Question595, Question596, Question597, Question598, Question599, Question600, 
			Question601, Question602, Question603, Question604, Question605, Question606, Question607, Question608, Question609, Question610, Question611, Question612, Question613, Question614, Question615, Question616, Question617, Question618, Question619, Question620, 
			Question621, Question622, Question623, Question624, Question625, Question626, Question627, Question628, Question629, Question630, Question631, Question632, Question633, Question634, Question635, Question636, Question637, Question638, Question639, Question640, 
			Question641, Question642, Question643, Question644, Question645, Question646, Question647, Question648, Question649, Question650, Question651, Question652, Question653, Question654, Question655, Question656, Question657, Question658, Question659, Question660, 
			Question661, Question662, Question663, Question664, Question665, Question666, Question667, Question668, Question669, Question670, Question671, Question672, Question673, Question674, Question675, Question676, Question677, Question678, Question679, Question680, 
			Question681, Question682, Question683, Question684, Question685, Question686, Question687, Question688, Question689, Question690, Question691, Question692, Question693, Question694, Question695, Question696, Question697, Question698, Question699, Question700, 
			Question701, Question702, Question703, Question704, Question705, Question706, Question707, Question708, Question709, Question710, Question711, Question712, Question713, Question714, Question715, Question716, Question717, Question718, Question719, Question720, 
			Question721, Question722, Question723, Question724, Question725, Question726, Question727, Question728, Question729, Question730, Question731, Question732, Question733, Question734, Question735, Question736, Question737, Question738, Question739, Question740, 
			Question741, Question742, Question743, Question744, Question745, Question746, Question747, Question748, Question749, Question750, Question751, Question752, Question753, Question754, Question755, Question756, Question757, Question758, Question759, Question760, 
			Question761, Question762, Question763, Question764, Question765, Question766, Question767, Question768, Question769, Question770, Question771, Question772, Question773, Question774, Question775, Question776, Question777, Question778, Question779, Question780, 
			Question781, Question782, Question783, Question784, Question785, Question786, Question787, Question788, Question789, Question790, Question791, Question792, Question793, Question794, Question795, Question796, Question797, Question798, Question799, Question800, 
			Question801, Question802, Question803, Question804, Question805, Question806, Question807, Question808, Question809, Question810, Question811, Question812, Question813, Question814, Question815, Question816, Question817, Question818, Question819, Question820, 
			Question821, Question822, Question823, Question824, Question825, Question826, Question827, Question828, Question829, Question830, Question831, Question832, Question833, Question834, Question835, Question836, Question837, Question838, Question839, Question840, 
			Question841, Question842, Question843, Question844, Question845, Question846, Question847, Question848, Question849, Question850, Question851, Question852, Question853, Question854, Question855, Question856
		};
		public string [] rowNames = {
			"Question1", "Question2", "Question3", "Question4", "Question5", "Question6", "Question7", "Question8", "Question9", "Question10", "Question11", "Question12", "Question13", "Question14", "Question15", "Question16", "Question17", "Question18", "Question19", "Question20", 
			"Question21", "Question22", "Question23", "Question24", "Question25", "Question26", "Question27", "Question28", "Question29", "Question30", "Question31", "Question32", "Question33", "Question34", "Question35", "Question36", "Question37", "Question38", "Question39", "Question40", 
			"Question41", "Question42", "Question43", "Question44", "Question45", "Question46", "Question47", "Question48", "Question49", "Question50", "Question51", "Question52", "Question53", "Question54", "Question55", "Question56", "Question57", "Question58", "Question59", "Question60", 
			"Question61", "Question62", "Question63", "Question64", "Question65", "Question66", "Question67", "Question68", "Question69", "Question70", "Question71", "Question72", "Question73", "Question74", "Question75", "Question76", "Question77", "Question78", "Question79", "Question80", 
			"Question81", "Question82", "Question83", "Question84", "Question85", "Question86", "Question87", "Question88", "Question89", "Question90", "Question91", "Question92", "Question93", "Question94", "Question95", "Question96", "Question97", "Question98", "Question99", "Question100", 
			"Question101", "Question102", "Question103", "Question104", "Question105", "Question106", "Question107", "Question108", "Question109", "Question110", "Question111", "Question112", "Question113", "Question114", "Question115", "Question116", "Question117", "Question118", "Question119", "Question120", 
			"Question121", "Question122", "Question123", "Question124", "Question125", "Question126", "Question127", "Question128", "Question129", "Question130", "Question131", "Question132", "Question133", "Question134", "Question135", "Question136", "Question137", "Question138", "Question139", "Question140", 
			"Question141", "Question142", "Question143", "Question144", "Question145", "Question146", "Question147", "Question148", "Question149", "Question150", "Question151", "Question152", "Question153", "Question154", "Question155", "Question156", "Question157", "Question158", "Question159", "Question160", 
			"Question161", "Question162", "Question163", "Question164", "Question165", "Question166", "Question167", "Question168", "Question169", "Question170", "Question171", "Question172", "Question173", "Question174", "Question175", "Question176", "Question177", "Question178", "Question179", "Question180", 
			"Question181", "Question182", "Question183", "Question184", "Question185", "Question186", "Question187", "Question188", "Question189", "Question190", "Question191", "Question192", "Question193", "Question194", "Question195", "Question196", "Question197", "Question198", "Question199", "Question200", 
			"Question201", "Question202", "Question203", "Question204", "Question205", "Question206", "Question207", "Question208", "Question209", "Question210", "Question211", "Question212", "Question213", "Question214", "Question215", "Question216", "Question217", "Question218", "Question219", "Question220", 
			"Question221", "Question222", "Question223", "Question224", "Question225", "Question226", "Question227", "Question228", "Question229", "Question230", "Question231", "Question232", "Question233", "Question234", "Question235", "Question236", "Question237", "Question238", "Question239", "Question240", 
			"Question241", "Question242", "Question243", "Question244", "Question245", "Question246", "Question247", "Question248", "Question249", "Question250", "Question251", "Question252", "Question253", "Question254", "Question255", "Question256", "Question257", "Question258", "Question259", "Question260", 
			"Question261", "Question262", "Question263", "Question264", "Question265", "Question266", "Question267", "Question268", "Question269", "Question270", "Question271", "Question272", "Question273", "Question274", "Question275", "Question276", "Question277", "Question278", "Question279", "Question280", 
			"Question281", "Question282", "Question283", "Question284", "Question285", "Question286", "Question287", "Question288", "Question289", "Question290", "Question291", "Question292", "Question293", "Question294", "Question295", "Question296", "Question297", "Question298", "Question299", "Question300", 
			"Question301", "Question302", "Question303", "Question304", "Question305", "Question306", "Question307", "Question308", "Question309", "Question310", "Question311", "Question312", "Question313", "Question314", "Question315", "Question316", "Question317", "Question318", "Question319", "Question320", 
			"Question321", "Question322", "Question323", "Question324", "Question325", "Question326", "Question327", "Question328", "Question329", "Question330", "Question331", "Question332", "Question333", "Question334", "Question335", "Question336", "Question337", "Question338", "Question339", "Question340", 
			"Question341", "Question342", "Question343", "Question344", "Question345", "Question346", "Question347", "Question348", "Question349", "Question350", "Question351", "Question352", "Question353", "Question354", "Question355", "Question356", "Question357", "Question358", "Question359", "Question360", 
			"Question361", "Question362", "Question363", "Question364", "Question365", "Question366", "Question367", "Question368", "Question369", "Question370", "Question371", "Question372", "Question373", "Question374", "Question375", "Question376", "Question377", "Question378", "Question379", "Question380", 
			"Question381", "Question382", "Question383", "Question384", "Question385", "Question386", "Question387", "Question388", "Question389", "Question390", "Question391", "Question392", "Question393", "Question394", "Question395", "Question396", "Question397", "Question398", "Question399", "Question400", 
			"Question401", "Question402", "Question403", "Question404", "Question405", "Question406", "Question407", "Question408", "Question409", "Question410", "Question411", "Question412", "Question413", "Question414", "Question415", "Question416", "Question417", "Question418", "Question419", "Question420", 
			"Question421", "Question422", "Question423", "Question424", "Question425", "Question426", "Question427", "Question428", "Question429", "Question430", "Question431", "Question432", "Question433", "Question434", "Question435", "Question436", "Question437", "Question438", "Question439", "Question440", 
			"Question441", "Question442", "Question443", "Question444", "Question445", "Question446", "Question447", "Question448", "Question449", "Question450", "Question451", "Question452", "Question453", "Question454", "Question455", "Question456", "Question457", "Question458", "Question459", "Question460", 
			"Question461", "Question462", "Question463", "Question464", "Question465", "Question466", "Question467", "Question468", "Question469", "Question470", "Question471", "Question472", "Question473", "Question474", "Question475", "Question476", "Question477", "Question478", "Question479", "Question480", 
			"Question481", "Question482", "Question483", "Question484", "Question485", "Question486", "Question487", "Question488", "Question489", "Question490", "Question491", "Question492", "Question493", "Question494", "Question495", "Question496", "Question497", "Question498", "Question499", "Question500", 
			"Question501", "Question502", "Question503", "Question504", "Question505", "Question506", "Question507", "Question508", "Question509", "Question510", "Question511", "Question512", "Question513", "Question514", "Question515", "Question516", "Question517", "Question518", "Question519", "Question520", 
			"Question521", "Question522", "Question523", "Question524", "Question525", "Question526", "Question527", "Question528", "Question529", "Question530", "Question531", "Question532", "Question533", "Question534", "Question535", "Question536", "Question537", "Question538", "Question539", "Question540", 
			"Question541", "Question542", "Question543", "Question544", "Question545", "Question546", "Question547", "Question548", "Question549", "Question550", "Question551", "Question552", "Question553", "Question554", "Question555", "Question556", "Question557", "Question558", "Question559", "Question560", 
			"Question561", "Question562", "Question563", "Question564", "Question565", "Question566", "Question567", "Question568", "Question569", "Question570", "Question571", "Question572", "Question573", "Question574", "Question575", "Question576", "Question577", "Question578", "Question579", "Question580", 
			"Question581", "Question582", "Question583", "Question584", "Question585", "Question586", "Question587", "Question588", "Question589", "Question590", "Question591", "Question592", "Question593", "Question594", "Question595", "Question596", "Question597", "Question598", "Question599", "Question600", 
			"Question601", "Question602", "Question603", "Question604", "Question605", "Question606", "Question607", "Question608", "Question609", "Question610", "Question611", "Question612", "Question613", "Question614", "Question615", "Question616", "Question617", "Question618", "Question619", "Question620", 
			"Question621", "Question622", "Question623", "Question624", "Question625", "Question626", "Question627", "Question628", "Question629", "Question630", "Question631", "Question632", "Question633", "Question634", "Question635", "Question636", "Question637", "Question638", "Question639", "Question640", 
			"Question641", "Question642", "Question643", "Question644", "Question645", "Question646", "Question647", "Question648", "Question649", "Question650", "Question651", "Question652", "Question653", "Question654", "Question655", "Question656", "Question657", "Question658", "Question659", "Question660", 
			"Question661", "Question662", "Question663", "Question664", "Question665", "Question666", "Question667", "Question668", "Question669", "Question670", "Question671", "Question672", "Question673", "Question674", "Question675", "Question676", "Question677", "Question678", "Question679", "Question680", 
			"Question681", "Question682", "Question683", "Question684", "Question685", "Question686", "Question687", "Question688", "Question689", "Question690", "Question691", "Question692", "Question693", "Question694", "Question695", "Question696", "Question697", "Question698", "Question699", "Question700", 
			"Question701", "Question702", "Question703", "Question704", "Question705", "Question706", "Question707", "Question708", "Question709", "Question710", "Question711", "Question712", "Question713", "Question714", "Question715", "Question716", "Question717", "Question718", "Question719", "Question720", 
			"Question721", "Question722", "Question723", "Question724", "Question725", "Question726", "Question727", "Question728", "Question729", "Question730", "Question731", "Question732", "Question733", "Question734", "Question735", "Question736", "Question737", "Question738", "Question739", "Question740", 
			"Question741", "Question742", "Question743", "Question744", "Question745", "Question746", "Question747", "Question748", "Question749", "Question750", "Question751", "Question752", "Question753", "Question754", "Question755", "Question756", "Question757", "Question758", "Question759", "Question760", 
			"Question761", "Question762", "Question763", "Question764", "Question765", "Question766", "Question767", "Question768", "Question769", "Question770", "Question771", "Question772", "Question773", "Question774", "Question775", "Question776", "Question777", "Question778", "Question779", "Question780", 
			"Question781", "Question782", "Question783", "Question784", "Question785", "Question786", "Question787", "Question788", "Question789", "Question790", "Question791", "Question792", "Question793", "Question794", "Question795", "Question796", "Question797", "Question798", "Question799", "Question800", 
			"Question801", "Question802", "Question803", "Question804", "Question805", "Question806", "Question807", "Question808", "Question809", "Question810", "Question811", "Question812", "Question813", "Question814", "Question815", "Question816", "Question817", "Question818", "Question819", "Question820", 
			"Question821", "Question822", "Question823", "Question824", "Question825", "Question826", "Question827", "Question828", "Question829", "Question830", "Question831", "Question832", "Question833", "Question834", "Question835", "Question836", "Question837", "Question838", "Question839", "Question840", 
			"Question841", "Question842", "Question843", "Question844", "Question845", "Question846", "Question847", "Question848", "Question849", "Question850", "Question851", "Question852", "Question853", "Question854", "Question855", "Question856"
		};
		public System.Collections.Generic.List<QuestionDatabaseRow> Rows = new System.Collections.Generic.List<QuestionDatabaseRow>();
		public override void AddRowGeneric (System.Collections.Generic.List<string> input)
		{
			Rows.Add(new QuestionDatabaseRow(input[0],input[1],input[2],input[3],input[4],input[5],input[6]));
		}
		public override void Clear ()
		{
			Rows.Clear();
		}
		public QuestionDatabaseRow GetRow(rowIds rowID)
		{
			QuestionDatabaseRow ret = null;
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
		public QuestionDatabaseRow GetRow(string rowString)
		{
			QuestionDatabaseRow ret = null;
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
