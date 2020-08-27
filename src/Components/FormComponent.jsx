import React from 'react';

class formComponent extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <form id="myForm">
                <label htmlFor="SearchPhrase">Search Phrase:</label>
                <input type="text" id="SearchPhrase" name="SearchPhrase"></input><br></br>
                <label htmlFor="Url">Url:</label>
                <input type="text" id="Url" name="Url"></input><br></br>
                <input onClick={this.props.search} defaultValue="Submit"></input><br></br>
                <input type="text" id="Result" name="Result" value={this.props.numberPositions} readOnly></input>
            </form>
        );
    }

}

export default formComponent;