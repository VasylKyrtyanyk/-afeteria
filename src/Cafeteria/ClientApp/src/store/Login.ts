import { stat } from "fs";
import { Action, Reducer } from "redux";
import { AppThunkAction } from ".";
import { authenticate } from "../api/auth";

export interface LoginState {
  isLoading: boolean;
  isError: boolean;
  user: User | null;
}

export interface User {
  username: string;
  password: string;
}

interface RequestLoginAction {
  type: "REQUEST_LOGIN";
  // user: User;
}

interface ResponseLoginAction {
  type: "RESPONSE_LOGIN";
  user: User;
}

export const actionCreators = {
  requestLogin: (
    username: string,
    password: string
  ): AppThunkAction<KnownAction> => (dispatch, getState) => {
    // Only load data if it's something we don't already have (and are not already loading)
    const appState = getState();
    // if (appState && appState.login) {
    //     fetch(`login`)
    //         .then(response => response.json() as Promise<User>)
    //         .then(data => {
    //             dispatch({ type: 'RESPONSE_LOGIN', user: data });
    //         });

    //     dispatch({ type: 'REQUEST_LOGIN' });
    // }
    const promise = authenticate(username, password);
    promise.then((response) => {
      if (response.status === 200) {
        dispatch({ type: "RESPONSE_LOGIN", user: response.data });
      }
    });
  },
};

type KnownAction = RequestLoginAction | ResponseLoginAction;

export const reducer: Reducer<LoginState> = (
  state: LoginState | undefined,
  incomingAction: Action
): LoginState => {
  if (state === undefined) {
    return {
      isLoading: false,
      user: { username: "", password: "" },
      isError: false,
    };
  }

  const action = incomingAction as KnownAction;
  switch (action.type) {
    case "REQUEST_LOGIN":
      return {
        isLoading: true,
        user: null,
        isError: false,
      };
    case "RESPONSE_LOGIN":
      return {
        isLoading: false,
        user: action.user,
        isError: false,
      };
    default:
      return state;
  }
};
