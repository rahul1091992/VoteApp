import { INavData } from '@coreui/angular';

export const navItems: INavData[] = [
  {
    name: 'Dashboard',
    url: '/dashboard',
    icon: 'icon-speedometer',
    badge: {
      variant: 'info',
      text: 'NEW'
    }
  },
  
  {
    title: true,
    name: 'Components'
  },
 
  {
    name: 'Elections',
    url: '/election',
    icon: 'icon-layers'
  },
  {
    name: 'Candidates',
    url: '/candidate',
    icon: 'icon-emotsmile'
  },
  {
    name: 'Voters',
    url: '/voters',
    icon: 'icon-people'
  },
  {
    name: 'Tolet Room/Flat',
    url: '/toletroom',
    icon: 'cui-bookmark'
  },
  {
    name: 'Payment',
    url: '/buttons',
    icon: 'cui-dollar',
    children: [
      {
        name: 'Make Payment',
        url: '/payment/makepayment',
      },
      {
        name: 'Payment History',
        url: '/payment/history',
      },
      {
        name: 'Pending Payment',
        url: '/payment/pending',
      },
      {
        name: 'Advance Payment',
        url: '/payment/advance',
      }
    ]
  },
  










  
];
