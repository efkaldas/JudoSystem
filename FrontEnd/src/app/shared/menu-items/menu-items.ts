import { Injectable } from '@angular/core';
import { LoginApiService } from '../../services/login.service';

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
}
const HEADERMENUITEMS = [
  { state: 'settings',type: 'link', name: 'Settings', icon: 'settings' },
  { state: 'profile', type: 'link', name: 'Profile', icon: 'account_box' },
  { state: 'disableNotifications', type: 'link', name: 'Disable Notifications', icon: 'notifications_off' },
  { state: 'logout', type: 'link', name: 'Sign Out', icon: 'exit_to_app' },
];

const MENUITEMS = [
  { state: 'judokas', type: 'link', name: 'Judokas', icon: 'people' },
  { state: 'starter', name: 'Starter Page', type: 'link', icon: 'av_timer' },
  { state: 'button', type: 'link', name: 'Buttons', icon: 'crop_7_5' },
  { state: 'grid', type: 'link', name: 'Grid List', icon: 'view_comfy' },
  { state: 'lists', type: 'link', name: 'Lists', icon: 'view_list' },
  { state: 'menu', type: 'link', name: 'Menu', icon: 'view_headline' },
  { state: 'tabs', type: 'link', name: 'Tabs', icon: 'tab' },
  { state: 'stepper', type: 'link', name: 'Stepper', icon: 'web' },
  {
    state: 'expansion',
    type: 'link',
    name: 'Expansion Panel',
    icon: 'vertical_align_center'
  },
  { state: 'chips', type: 'link', name: 'Chips', icon: 'vignette' },
  { state: 'toolbar', type: 'link', name: 'Toolbar', icon: 'voicemail' },
  {
    state: 'progress-snipper',
    type: 'link',
    name: 'Progress snipper',
    icon: 'border_horizontal'
  },
  {
    state: 'progress',
    type: 'link',
    name: 'Progress Bar',
    icon: 'blur_circular'
  },
  {
    state: 'dialog',
    type: 'link',
    name: 'Dialog',
    icon: 'assignment_turned_in'
  },
  { state: 'tooltip', type: 'link', name: 'Tooltip', icon: 'assistant' },
  { state: 'snackbar', type: 'link', name: 'Snackbar', icon: 'adb' },
  { state: 'slider', type: 'link', name: 'Slider', icon: 'developer_mode' },
  {
    state: 'slide-toggle',
    type: 'link',
    name: 'Slide Toggle',
    icon: 'all_inclusive'
  }
];

@Injectable()
export class MenuItems extends LoginApiService{
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
  getHeaderMenuitem(): Menu[] {
    return HEADERMENUITEMS;
  }
}
