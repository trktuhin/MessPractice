import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/home-page'
import Register from 'components/register'
import Login from 'components/login'
import Team from 'components/team'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap' },
  { name: 'fetch-data', path: '/fetch-data', component: FetchData, display: 'Fetch data', icon: 'list' },
  { name: 'register', path: '/register', component: Register, display: 'Register', icon: 'list' },
  { name: 'login', path: '/login', component: Login, display: 'Login', icon: 'list' },
  { name: 'team', path: '/team', component: Team, display: 'Team', icon: 'list' }

]
