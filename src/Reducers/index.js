export const initialState = {
    NumberPositions: ""
};

export const Reducer = (state = initialState, action) => {


    switch (action.type) {
        case 'STORENUMBERPOSITIONS':
            return Object.assign({}, state, { NumberPositions: action.numberPositions});

        default:
            return state;
    }
};




