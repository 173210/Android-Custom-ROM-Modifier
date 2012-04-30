s/ *= */=/g

s/ro.build.user=.*/ro.build.user=SC02C/
s/ro.product.model=.*/ro.product.model=SC-02C/
s/ro.product.brand=.*/ro.product.brand=samsung/
s/ro.product.name=.*/ro.product.name=SC-02C/
s/ro.product.manufacturer=.*/ro.product.manufacturer=samsung/
s/ro.product.locale.language=.*/ro.product.locale.language=ja/
s/ro.product.locale.region=.*/ro.product.locale.region=JP/
s/ro.product.locale.product=.*/ro.build.product=SC-02C/
s/ro.build.description=.*/ro.build.description=SC-02C-user 2.3.6 GINGERBREAD OMKL4 release-keys/
s%ro.build.fingerprint=.*%ro.build.fingerprint=samsung/SC-02C/SC-02C:2.3.6/GINGERBREAD/OMKL4:user/release-keys%
s/wifi.supplicant_scan_interval=.*/wifi.supplicant_scan_interval=180/g
s/ro.ril.hsxpa=.*/ro.ril.hsxpa=2/g
s/ro.ril.enable.managed.roaming=.*/ro.ril.enable.managed.roaming=1/g
s/ro.ril.oem.nosim.ecclist=.*/ro.ril.oem.nosim.ecclist=110,118,119/g
s/ro.ril.disable.fd.plmn.prefix=.*/ro.ril.disable.fd.plmn.prefix=44010/g
s/ro.telephony.default_network=.*/ro.telephony.default_network=2/g


$s/$/\
/
$s/$/#/g
$s/$/\
/

$s/$/# Add/g
$s/$/\
/
