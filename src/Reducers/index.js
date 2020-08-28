export const initialState = {
    NumberPositions: "",
    ShowSpinner: false
};

export const Reducer = (state = initialState, action) => {


    switch (action.type) {
        case 'STORENUMBERPOSITIONS':
            return Object.assign({}, state, { NumberPositions: action.numberPositions });
        case 'LOADERSPINNER':
            return Object.assign({}, state, { ShowSpinner: action.showSpinner });
        default:
            return state;
    }
};




