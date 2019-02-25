import axios from 'axios'
import router from '../router/index'

const state={
    token: null,
    userId: null,
    expireTime: null,
    firstName:null,
    lastName:null
}

const getters = {
    isAuthenticated(state){
        return state.token!=null;
    },
    getToken(state){
        return state.token;
    },
    getState(state){
        return state;
    },
    getExpirationTime(state){
        return state.expireTime;
    },
    getUserId(state){
        return state.userId;
    },
    getFullName(){
        return state.firstName+" "+state.lastName;
    }
}

const mutations={
    authData:(state,payload)=>{
        state.token=payload.token;
        state.userId=payload.userId;
        state.expireTime=payload.expireTime;
        state.firstName=payload.firstName;
        state.lastName=payload.lastName;

    },
    clearAuth:(state)=>{
        state.token=null;
        state.userId=null;
        state.expireTime=null;
    }
}

const actions={
    login({commit,dispatch},authData){
        commit('changeLoader');
        axios.post('/api/account/login',authData)
        .then(({data})=>{
            localStorage.setItem('token',data.token);
            localStorage.setItem('userId',data.userId);
            localStorage.setItem('expireTime',data.expireTime);
            localStorage.setItem('firstName',data.firstName);
            localStorage.setItem('lastName',data.lastName);

            commit('authData',data);
            this._vm.$http.defaults.headers.common['Authorization']="bearer "+data.token;
            router.push('/');
            dispatch('tryLogout');
        })
        .catch(()=>{
            // here should be toaster showing error message
        })
        .then(() => {
            commit('changeLoader');
            
        })
    },
    register({commit,dispatch},registerModel){
        commit('changeLoader');
        axios.post('/api/account/Register',registerModel)
        .then(({data})=>{
            localStorage.setItem('token',data.token);
            localStorage.setItem('userId',data.userId);
            localStorage.setItem('expireTime',data.expireTime);
            localStorage.setItem('firstName',data.firstName);
            localStorage.setItem('lastName',data.lastName);

            commit('authData',data);
            
            this._vm.$http.defaults.headers.common['Authorization']="bearer "+data.token;
            router.push('/');
            dispatch('tryLogout');
        })
        .catch(()=>{
            // here should be toaster showing error message
        })
        .then(()=>{
            commit('changeLoader');
        });
    },
    tryLogin({commit,dispatch}){
        let token=localStorage.getItem('token');
        if(!token){
            return;
        }
        let expireIn=localStorage.getItem('expireTime');
        let userId=localStorage.getItem('userId');
        const expireTime=new Date(expireIn);
        let firstName=localStorage.getItem('firstName');
        let lastName=localStorage.getItem('lastName');
        const now=new Date();
        if(now>=expireTime){
            return;
        }
        this._vm.$http.defaults.headers.common['Authorization']="bearer "+token;
        commit('authData',{userId,token,expireTime,firstName,lastName});
        dispatch('tryLogout');

    },
    logout({commit}){
        localStorage.removeItem('token');
        localStorage.removeItem('expireTime');
        localStorage.removeItem('userId');

        commit('clearAuth');
        delete this._vm.$http.defaults.headers.common['Authorization'];
        router.replace('/login')
    },
    tryLogout({dispatch}){
        let expireTime=new Date(localStorage.getItem('expireTime'));
        let miliseconds=this._vm.$moment(expireTime).diff(new Date(),'seconds')*1000;
        setTimeout(() => dispatch('logout'), miliseconds);
    }
}

export default {
    state,
    getters,
    mutations,
    actions
}