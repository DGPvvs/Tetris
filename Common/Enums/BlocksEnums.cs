namespace Tetris.Common.Enums
{
	enum Block_Names
	{
		NULL_BLOCK = '\0',
		L_BLOCK = 'L',
		J_BLOCK = 'J',
		I_BLOCK = 'I',
		O_BLOCK = 'O',
		S_BLOCK = 'S',
		T_BLOCK = 'T',
		Z_BLOCK = 'Z'
	};

	enum Block_Index
	{
		EMPTY_INDEX = 0,
		L_INDEX,
		J_INDEX,
		I_INDEX,
		O_INDEX,
		S_INDEX,
		T_INDEX,
		Z_INDEX
	};


	enum Color_Index
	{
		EMPTY_INDEX = 0,
		L_INDEX,
		J_INDEX,
		I_INDEX,
		O_INDEX,
		S_INDEX,
		T_INDEX,
		Z_INDEX
	};

	enum ROTATION_STATE
	{
		ROTATION_STATE_0 = 0,
		ROTATION_STATE_1 = 1,
		ROTATION_STATE_2 = 2,
		ROTATION_STATE_3 = 3
	};
}
