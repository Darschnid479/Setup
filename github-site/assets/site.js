/* Presentation enhancements only. No signup automation or credentials. */
(() => {
  'use strict';
  const root = document.documentElement;
  const motion = window.matchMedia('(prefers-reduced-motion: reduce)');
  const themeButton = document.getElementById('theme');
  let storedTheme = null;
  try { storedTheme = localStorage.getItem('ki-showcase-theme'); } catch (_) {}
  function applyTheme(theme) {
    if (theme === 'light') root.dataset.theme = 'light'; else delete root.dataset.theme;
    themeButton.setAttribute('aria-label', theme === 'light' ? 'Bytt til mørkt tema' : 'Bytt til lyst tema');
  }
  applyTheme(storedTheme === 'light' ? 'light' : 'dark');
  themeButton.addEventListener('click', () => {
    const theme = root.dataset.theme === 'light' ? 'dark' : 'light';
    applyTheme(theme);
    try { localStorage.setItem('ki-showcase-theme', theme); } catch (_) {}
  });
  const logo = document.querySelector('.brand-mark img');
  logo.addEventListener('load', () => { logo.parentElement.classList.remove('no-logo'); logo.parentElement.classList.add('has-logo'); });
  logo.addEventListener('error', () => { logo.parentElement.classList.remove('has-logo'); logo.parentElement.classList.add('no-logo'); });
  if (logo.complete && logo.naturalWidth) logo.parentElement.classList.add('has-logo');
  else if (logo.complete) logo.parentElement.classList.add('no-logo');

  if (!motion.matches && 'IntersectionObserver' in window) {
    const observer = new IntersectionObserver(entries => entries.forEach(entry => {
      if (entry.isIntersecting) { entry.target.classList.add('visible'); observer.unobserve(entry.target); }
    }), { threshold: 0.07 });
    document.querySelectorAll('.reveal').forEach(el => observer.observe(el));
    root.classList.add('motion');
  }
  motion.addEventListener('change', () => {
    if (motion.matches) root.classList.remove('motion');
    updateScroll();
  });
  let ticking = false;
  function updateScroll() {
    const max = document.documentElement.scrollHeight - innerHeight;
    document.querySelector('.scroll-meter').style.transform = `scaleX(${max > 0 ? Math.min(1,Math.max(0,scrollY/max)) : 0})`;
    document.querySelector('.hero-window').style.setProperty('--hero-y', `${motion.matches ? 0 : Math.max(-22, -scrollY * 0.035)}px`);
    ticking = false;
  }
  window.addEventListener('scroll', () => { if (!ticking) { ticking=true; requestAnimationFrame(updateScroll); } }, { passive: true });
  window.addEventListener('resize', updateScroll);
  updateScroll();

  const tabs = Array.from(document.querySelectorAll('[role="tab"]'));
  const image = document.getElementById('gallery-image');
  function activateTab(tab, focus=false) {
    tabs.forEach(t => { const selected = t === tab; t.setAttribute('aria-selected', String(selected)); t.tabIndex = selected ? 0 : -1; });
    document.getElementById('gallery-panel').setAttribute('aria-labelledby', tab.id);
    image.src = `assets/screenshots/${tab.dataset.image}`;
    image.alt = `UI-forhåndsvisning: ${tab.dataset.title}`;
    document.getElementById('gallery-title').textContent = tab.dataset.title;
    document.getElementById('gallery-description').textContent = tab.dataset.description;
    if (focus) tab.focus();
  }
  tabs.forEach((tab,index) => {
    tab.addEventListener('click', () => activateTab(tab));
    tab.addEventListener('keydown', event => {
      let target = null;
      if (event.key === 'ArrowRight') target = tabs[(index+1)%tabs.length];
      if (event.key === 'ArrowLeft') target = tabs[(index-1+tabs.length)%tabs.length];
      if (event.key === 'Home') target = tabs[0];
      if (event.key === 'End') target = tabs[tabs.length-1];
      if (target) { event.preventDefault(); activateTab(target,true); }
    });
  });
  const dialog = document.getElementById('image-dialog');
  document.getElementById('enlarge').addEventListener('click', () => {
    if (typeof dialog.showModal !== 'function') { window.open(image.src,'_blank','noopener'); return; }
    document.getElementById('dialog-image').src=image.src;
    document.getElementById('dialog-image').alt=image.alt;
    document.getElementById('dialog-title').textContent=image.alt;
    dialog.showModal();
  });
  document.getElementById('close-dialog').addEventListener('click', () => dialog.close());
  dialog.addEventListener('click', event => { if (event.target===dialog) { const r=dialog.getBoundingClientRect(); if(event.clientX<r.left || event.clientX>r.right || event.clientY<r.top || event.clientY>r.bottom) dialog.close(); } });
  document.getElementById('copy-clone').addEventListener('click', async () => {
    const text=document.getElementById('clone-command').textContent;
    try {
      if (!navigator.clipboard) throw new Error('Clipboard unavailable');
      await navigator.clipboard.writeText(text);
      document.getElementById('copy-status').textContent='Kommandoen er kopiert.';
    } catch (_) {
      const selection=window.getSelection(); const range=document.createRange();
      range.selectNodeContents(document.getElementById('clone-command')); selection.removeAllRanges(); selection.addRange(range);
      document.getElementById('copy-status').textContent='Kommandoen er markert. Bruk Ctrl+C eller Kopier.';
    }
  });
  async function updateRelease() {
    const status = document.getElementById('release-info');
    const controller = new AbortController();
    const timer = setTimeout(() => controller.abort(), 7000);
    try {
      const response = await fetch('https://api.github.com/repos/Darschnid479/Setup/releases/latest', { headers:{Accept:'application/vnd.github+json'}, signal:controller.signal, credentials:'omit', referrerPolicy:'no-referrer' });
      if (response.status === 404) { status.textContent='Ingen offentlig stabil release funnet ennå. Se Releases for tilgjengelige utgaver.'; return; }
      if (!response.ok) throw new Error('Release data unavailable');
      const release = await response.json();
      if (release.draft || release.prerelease || !Array.isArray(release.assets)) throw new Error('Unexpected release');
      const asset=release.assets.find(a => typeof a.name==='string' && /win[-_]x64.*\.zip$/i.test(a.name) && a.state==='uploaded');
      if (!asset) { status.textContent=`Siste stabile versjon: ${String(release.tag_name || 'se Releases')}. Velg riktig fil på GitHub.`; return; }
      const url = new URL(asset.browser_download_url);
      if (url.protocol!=='https:' || url.hostname!=='github.com' || !url.pathname.startsWith('/Darschnid479/Setup/releases/download/')) throw new Error('Unexpected download URL');
      document.querySelectorAll('[data-download]').forEach(a => { a.href=url.href; a.textContent='Last ned Windows x64 ↓'; });
      const size=Number(asset.size); const mb=Number.isFinite(size) && size>0 ? ` · ${(size/1048576).toFixed(1)} MB` : '';
      status.textContent=`${String(release.tag_name || 'Siste stabile release')}${mb} · Fil fra GitHub Releases. Les versjonsnotatene før bruk.`;
    } catch (_) { status.textContent='Kunne ikke hente versjonsstatus nå. Åpne Releases for oppdatert informasjon.'; }
    finally { clearTimeout(timer); }
  }
  updateRelease();
})();
