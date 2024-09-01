import { AtendoCloudSystemTemplatePage } from './app.po';

describe('AtendoCloudSystem App', function() {
  let page: AtendoCloudSystemTemplatePage;

  beforeEach(() => {
    page = new AtendoCloudSystemTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
