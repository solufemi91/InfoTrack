import { connect } from 'react-redux';
import formComponent from '../Components/FormComponent';

const submitDataToServer = (dispatch) => {
    const form = document.getElementById("myForm");
    const XHR = new XMLHttpRequest();

    const FD = new FormData(form);

    XHR.addEventListener("load", function (event) {
        let result = event.target.responseText;
        dispatch({ type: 'STORENUMBERPOSITIONS', numberPositions: result })
    });

    XHR.addEventListener("error", function (event) {
        alert('Oops! Something went wrong.');
    });

    XHR.open("POST", "http://localhost:50756/GoogleSearchPositionData/ReturnOrderingPositions");

    XHR.send(FD)
}

const mapDispatchToProps = (dispatch) => {
    return {
        search: () => {
            submitDataToServer(dispatch)
        }
    };
};


const mapStateToProps = (state) => {
    return {
        numberPositions: state.NumberPositions
    }
}

const formComponentContainer = connect(mapStateToProps, mapDispatchToProps)(formComponent);

export default formComponentContainer;