// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  API_URL: 'https://localhost:5001/api/',
  img_garoon: 'http://cptsvs522/cbgrn/grn/image/customimg/emp_pic/',
  status: {
    wait: "Wait",
    approved: "Approved",
    center_app: "Center Approved"
  },
  call: "8005",
  text: {
    success: "Update data success.",
    delete: "Delete data success.",
    wait: "Wait",
    duplication: "Duplication Data.",
    not_found: "Data not found.",
    all : "All"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.

// ng build --baseHref=/HRGIS_TEST/
// ng build --prod --base-href=/HRGIS_TEST/
// npm uninstall

// API_URL: 'https://localhost:5001/api/',
// API_URL: 'http://cptsvs531:5000/api-hrgis/api/',