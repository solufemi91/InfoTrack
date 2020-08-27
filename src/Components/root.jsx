import { Reducer } from '../Reducers';
import { render } from 'react-dom'
import { createStore, compose } from 'redux';
import FormComponentContainer from '../Containers/formComponentContainer';
import { Provider } from 'react-redux';


const enhancers = compose(
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
);

const store = createStore(
    Reducer, enhancers
);

const domContainer = document.getElementById('reactContainer');

render(
    <Provider store={store}>
        <FormComponentContainer />,
    </Provider>,
    domContainer); 