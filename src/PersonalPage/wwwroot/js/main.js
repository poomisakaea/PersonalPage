/**
 * Personal Page - Main JavaScript
 * Handles email copy functionality with progressive enhancement
 * TH: โปรแกรมหลักสำหรับคัดลอกอีเมล
 */

(function () {
  'use strict';

  const FEEDBACK_DURATION = 2000; // 2 seconds - TH: 2 วินาที

  /**
   * Copy email to clipboard using Clipboard API with fallback
   * TH: คัดลอกอีเมลไปยังคลิปบอร์ดโดยใช้ Clipboard API พร้อม fallback
   */
  function copyEmailToClipboard(email) {
    // Try modern Clipboard API first
    if (navigator.clipboard && window.isSecureContext) {
      return navigator.clipboard
        .writeText(email)
        .then(() => {
          showFeedback(true);
          return true;
        })
        .catch(() => {
          // Fallback to old method
          return fallbackCopyToClipboard(email);
        });
    } else {
      // Fallback for older browsers or insecure context
      return Promise.resolve(fallbackCopyToClipboard(email));
    }
  }

  /**
   * Fallback method using textarea (for older browsers)
   * TH: วิธี fallback โดยใช้ textarea
   */
  function fallbackCopyToClipboard(email) {
    const textarea = document.createElement('textarea');
    textarea.value = email;
    textarea.setAttribute('readonly', '');
    textarea.style.position = 'absolute';
    textarea.style.left = '-9999px';
    
    document.body.appendChild(textarea);
    
    try {
      textarea.select();
      const successful = document.execCommand('copy');
      showFeedback(successful);
      return successful;
    } catch (err) {
      console.error('Failed to copy:', err);
      showFeedback(false);
      return false;
    } finally {
      document.body.removeChild(textarea);
    }
  }

  /**
   * Show visual feedback for copy action
   * TH: แสดงข้อมูลป้อนกลับสำหรับการคัดลอก
   */
  function showFeedback(success) {
    const button = document.getElementById('copyEmail');
    if (!button) return;

    const originalText = button.textContent;
    const feedbackText = success ? 'Copied! / คัดลอกแล้ว!' : 'Failed to copy / คัดลอกไม่สำเร็จ';
    
    button.textContent = feedbackText;
    button.classList.add('email-copy--copied');
    
    // Reset after delay
    setTimeout(() => {
      button.textContent = originalText;
      button.classList.remove('email-copy--copied');
    }, FEEDBACK_DURATION);
  }

  /**
   * Initialize copy button
   * TH: เริ่มต้นปุ่มคัดลอก
   */
  function initializeCopyButton() {
    const button = document.getElementById('copyEmail');
    if (!button) return;

    const email = button.getAttribute('data-email') || 
                  document.querySelector('.email-link')?.getAttribute('data-email');
    
    if (!email) return;

    button.addEventListener('click', (event) => {
      event.preventDefault();
      copyEmailToClipboard(email);
    });

    // Keyboard support (Enter/Space)
    button.addEventListener('keydown', (event) => {
      if (event.key === 'Enter' || event.key === ' ') {
        event.preventDefault();
        copyEmailToClipboard(email);
      }
    });
  }

  /**
   * Enhance email link with data attribute
   * TH: ปรับปรุงลิงก์อีเมลด้วยแอตทริบิวต์ข้อมูล
   */
  function enhanceEmailLink() {
    const emailLink = document.querySelector('.email-link');
    if (emailLink && emailLink.href.startsWith('mailto:')) {
      const email = emailLink.href.replace('mailto:', '');
      if (!emailLink.hasAttribute('data-email')) {
        emailLink.setAttribute('data-email', email);
      }
    }
  }

  /**
   * DOM ready handler
   * TH: ตัวจัดการเตรียม DOM
   */
  function init() {
    // Enhance email link first
    enhanceEmailLink();
    
    // Initialize copy button
    initializeCopyButton();
    
    // Log that script has loaded (for debugging)
    console.log('[PersonalPage] Main script loaded');
  }

  // Wait for DOM to be ready
  if (document.readyState === 'loading') {
    document.addEventListener('DOMContentLoaded', init);
  } else {
    init();
  }
})();
